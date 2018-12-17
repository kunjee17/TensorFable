namespace TrainingProgress

open Fable.Core
open CommonTypes
open TensorFlow
open TensorFlow.Data

module Types =
    type Model =
        { Status : string
          Message : string
          SelectedModelType : ModelType
          Epochs : int
          TfModel : obj
          Data : TfData }

    type Msg =
        | LogStatus of string
        | TrainingLog of string
        | StartTraining of ModelType * int
        | Loaded of TfData
        | CreatedModel
        | TrainedModel
        | Exn of exn

module State =
    open Elmish
    open Types
    open JsInterop
    open Fable.Import.JS

    let train (tfmodel) (onIteration) (model) dispatch =
        promise {
            LogStatus "Training Model" |> dispatch
            // Now that we've defined our model, we will define our optimizer. The
            // optimizer will be used to optimize our model's weight values during
            // training so that we can decrease our training loss and increase our
            // classification accuracy.
            // The learning rate defines the magnitude by which we update our weights each
            // training step. The higher the value, the faster our loss values converge,
            // but also the more likely we are to overshoot optimal parameters
            // when making an update. A learning rate that is too low will take too long
            // to find optimal (or good enough) weight parameters while a learning rate
            // that is too high may overshoot optimal parameters. Learning rate is one of
            // the most important hyperparameters to set correctly. Finding the right
            // value takes practice and is often best found empirically by trying many
            // values.
            let LearningRate = 0.01
            // We are using rmsprop as our optimizer.
            // An optimizer is an iterative method for minimizing an loss function.
            // It tries to find the minimum of our loss function with respect to the
            // model's weight parameters.
            let optimizer = "rmsprop"
            // We compile our model by specifying an optimizer, a loss function, and a
            // list of metrics that we will use for model evaluation. Here we're using a
            // categorical crossentropy loss, the standard choice for a multi-class
            // classification problem like MNIST digits.
            // The categorical crossentropy loss is differentiable and hence makes
            // model training possible. But it is not amenable to easy interpretation
            // by a human. This is why we include a "metric", namely accuracy, which is
            // simply a measure of how many of the examples are classified correctly.
            // This metric is not differentiable and hence cannot be used as the loss
            // function of the model.
            tfmodel?compile (createObj [ "optimizer" ==> optimizer
                                         "loss" ==> "categoricalCrossentropy"
                                         "metrics" ==> [ "accuracy" ] ])
            // Batch size is another important hyperparameter. It defines the number of
            // examples we group together, or batch, between updates to the model's
            // weights during training. A value that is too low will update weights using
            // too few examples and will not generalize well. Larger batch sizes require
            // more memory resources and aren't guaranteed to perform better.
            let batchSize = 320
            // Leave out the last 15% of the training data for validation, to monitor
  // overfitting during training.
            let validationSplit = 0.15
            // Get number of training epochs from the UI.
            let trainEpochs = model.Epochs
            // We'll keep a buffer of loss and accuracy values over time.
            let trainBatchCount = 0

            let trainData = getTrainData()
            let testData = getTestData(None)
            let totalNumBatches = Math.ceil(trainData.xs.shape.[0] * (1. - validationSplit) / (float batchSize)) * (float trainEpochs)
            return ()
        }

    let init() : Model * Cmd<Msg> =
        { Status = ""
          Message = ""
          SelectedModelType = ConvNet
          Epochs = 0
          TfModel = createObj []
          Data =
              { TestImages = Float32Array.Create 0.
                TrainImages = Float32Array.Create 0.
                TestLabels = Uint8Array.Create 0.
                TrainLabels = Uint8Array.Create 0. } }, Cmd.none

    let update msg model =
        match msg with
        | LogStatus s -> { model with Status = s }, Cmd.none
        | TrainingLog m ->
            { model with Message = model.Message + "\n" + m }, Cmd.none
        | StartTraining(m, e) ->
            { model with SelectedModelType = m
                         Epochs = e },
            Cmd.batch [ Cmd.ofMsg (LogStatus "Loading MNIST Data...")
                        Cmd.ofPromise load () (Loaded) (Exn) ]
        | Loaded x ->
            printfn "Loaded"
            let m =
                match model.SelectedModelType with
                | ConvNet -> createConvModel()
                | DenseNet -> createDenseModel()
            { model with TfModel = m
                         Data = x },
            Cmd.batch [ Cmd.ofMsg (LogStatus "Creating Model...")
                        Cmd.ofMsg CreatedModel ]
        | CreatedModel ->
            printfn "Created model"
            model.TfModel?summary ()
            model,
            Cmd.batch [ Cmd.ofMsg (LogStatus "Starting model training...")
                        //train model
                        Cmd.ofMsg TrainedModel ]
        | TrainedModel ->
            printfn "Trained Model"
            model, Cmd.none
        | Exn ex ->
            printfn "%A" ex
            model, Cmd.none

module View =
    open Elmish
    open Elmish.React
    open Fable.Helpers.React
    open Fable.Helpers.React.Props
    open Types

    let root (model : Model) =
        section []
            [ p [ Class "section-head" ] [ str "Training Progress" ]
              p [ Id "status" ] [ str model.Status ]
              p [ Id "message" ] [ str model.Message ]

              div [ Id "stats" ]
                  [ div [ Class "canvases" ] [ label [ Id "loss-label" ] []
                                               div [ Id "loss-canvas" ] [] ]
                    div [ Class "canvases" ] [ label [ Id "accuracy-label" ] []
                                               div [ Id "accuracy-canvas" ] [] ] ] ]
