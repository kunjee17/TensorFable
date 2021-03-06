module TensorFlow.Data

open Fable.Core
open Fable.Import.Browser
open PromiseImpl
open Fable.Import.JS
open Fetch
open Fable.Core.JsInterop
open Fable.Import.Tfjs.Types
open Fable.Import.Tfjs.Tensor

let tf : obj = importAll "@tensorflow/tfjs"

[<Literal>]
let ImageHeight = 28

[<Literal>]
let ImageWidth = 28

let ImageSize = ImageHeight * ImageWidth

[<Literal>]
let NumClasses = 10

[<Literal>]
let NumDatasetElements = 65000

[<Literal>]
let NumTrainElements = 55000

let NumTestElements = NumDatasetElements - NumTrainElements

[<Literal>]
let MNISTImagesSpritePath =
    "https://storage.googleapis.com/learnjs-data/model-builder/mnist_images.png"

[<Literal>]
let MNISTLabelsPath =
    "https://storage.googleapis.com/learnjs-data/model-builder/mnist_labels_uint8"

let mutable datasetImages : Float32Array = Float32Array.Create 0.
let mutable datasetLabels : Uint8Array = Uint8Array.Create 0.
let mutable trainImages : Float32Array = Float32Array.Create 0.
let mutable testImages : Float32Array = Float32Array.Create 0.
let mutable trainLabels : Uint8Array = Uint8Array.Create 0.
let mutable testLabels : Uint8Array = Uint8Array.Create 0.

type TfData =
    { TrainImages : Float32Array
      TestImages : Float32Array
      TrainLabels : Uint8Array
      TestLabels : Uint8Array }

let load() =
    promise {
        let img = Image.Create()
        let canvas = document.createElement ("canvas") :?> HTMLCanvasElement
        let ctx = canvas.getContext_2d()

        let imageRequest =
            promise {
                img.crossOrigin <- ""
                img.onload <- (fun _ ->
                img.width <- img.naturalWidth
                img.height <- img.naturalHeight
                let datasetBytesBuffer =
                    ArrayBuffer.Create
                        (NumDatasetElements * ImageSize * 4 |> float)
                let chunkSize = 5000
                canvas.width <- img.width
                canvas.height <- float chunkSize
                for i = 0 to (NumDatasetElements / chunkSize) do
                    let datasetBytesView =
                        Float32Array.Create
                            (datasetBytesBuffer,
                             (i * ImageSize * chunkSize * 4) |> float,
                             (ImageSize * chunkSize) |> float)
                    printfn "%A" datasetBytesView
                    ctx.drawImage
                        (U3.Case1 img, 0., i * chunkSize |> float, img.width,
                         chunkSize |> float, 0., 0., img.width,
                         chunkSize |> float)
                    let imageData =
                        ctx.getImageData (0., 0., canvas.width, canvas.height)
                    for j = 0 to ((int imageData.data.length) / 4) do
                        datasetBytesView.[j] <- imageData.data.[j * 4] / 255.
                    datasetImages <- Float32Array.Create(datasetBytesBuffer)
                    )
                img.src <- MNISTImagesSpritePath
                return ()
            }

        let labelsRequest = fetch MNISTLabelsPath []
        let! imageResponse = imageRequest
        let! labelsResponse = labelsRequest
        let! datasetLablesBufferSize = labelsResponse.arrayBuffer()
        datasetLabels <- Uint8Array.Create datasetLablesBufferSize
        trainImages <- datasetImages.slice
                           (0., ImageSize * NumTrainElements |> float)
        testImages <- datasetImages.slice
                          (ImageSize * NumTrainElements |> float)
        trainLabels <- datasetLabels.slice
                           (0., NumClasses * NumTrainElements |> float)
        testLabels <- datasetLabels.slice
                          (NumClasses * NumTrainElements |> float)
        return { TrainImages = trainImages
                 TestImages = testImages
                 TrainLabels = trainLabels
                 TestLabels = testLabels }
    }

type TensorData =
    { xs : Tensor<Rank> //R4 types
      labels : Tensor<Rank> //R2 types
                            }

let getTrainData() =
    let xs =
        tf?tensor4d (trainImages,
                     [| trainImages.length / float ImageSize
                        float ImageHeight
                        float ImageWidth
                        1. |])

    let labels =
        tf?tensor2d (trainImages,
                     [| trainLabels.length / float NumClasses
                        float NumClasses |])

    { xs = xs
      labels = labels }

let getTestData (numOfExamples : int option) =
    let xs =
        tf?tensor4d (testImages,
                     [| testImages.length / float ImageSize
                        float ImageHeight
                        float ImageWidth
                        1. |])

    let labels =
        tf?tensor2d (testLabels,
                     [| testLabels.length / float NumClasses
                        float NumClasses |])

    match numOfExamples with
    | Some i ->
        let xs' =
            xs?slice ([| 0.; 0.; 0.; 0. |],
                      [| float i
                         float ImageHeight
                         float ImageWidth
                         float 1 |])

        let labels' =
            labels?slice ([| 0.; 0. |],
                          [| float i
                             float NumClasses |])

        { xs = xs'
          labels = labels' }
    | None ->
        { xs = xs
          labels = labels }
