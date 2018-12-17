module TensorFlow

open Fable.Core
open Fable.Import.Browser
open PromiseImpl
open Fable.Import.JS
open Fetch
open Fable.Core.JsInterop
open Fable.Import.Tfjs.Types
// This is a helper class for loading and managing MNIST data specifically.
// It is a useful example of how you could create your own data manager class
// for arbitrary data though. It's worth a look :)
open TensorFlow.Data

let tf : obj = importAll "@tensorflow/tfjs"

(**
* Creates a convolutional neural network (Convnet) for the MNIST data.
*
* @returns {tf.Model} An instance of tf.Model.
*)
let createConvModel() =
    // Create a sequential neural network model. tf.sequential provides an API
    // for creating "stacked" models where the output from one layer is used as
    // the input to the next layer.
    let model = tf?sequential()
    // The first layer of the convolutional neural network plays a dual role:
    // it is both the input layer of the neural network and a layer that performs
    // the first convolution operation on the input. It receives the 28x28 pixels
    // black and white images. This input layer uses 16 filters with a kernel size
    // of 5 pixels each. It uses a simple RELU activation function which pretty
    // much just looks like this: __/
    model?add (tf?layers?conv2d (createObj [
                                            "inputShape" ==> Array.Create(ImageHeight, ImageWidth, 1)
                                            "kernelSize" ==> 3
                                            "filters" ==> 16
                                            "activation" ==> "relu" ]))
    // After the first layer we include a MaxPooling layer. This acts as a sort of
    // downsampling using max values in a region instead of averaging.
    // https://www.quora.com/What-is-max-pooling-in-convolutional-neural-networks
    model?add (tf?layers?maxPooling2d (createObj [ "poolSize" ==> 2
                                                   "strides" ==> 2 ]))
    // Our third layer is another convolution, this time with 32 filters.
    model?add (tf?layers?conv2d (createObj [ "kernelSize" ==> 3
                                             "filters" ==> 32
                                             "activation" ==> "relu" ]))
    // Max pooling again.
    model?add (tf?layers?maxPooling2d (createObj [ "poolSize" ==> 2
                                                   "strides" ==> 2 ]))
    // Add another conv2d layer.
    model?add (tf?layers?conv2d (createObj [ "kernelSize" ==> 3
                                             "filters" ==> 32
                                             "activation" ==> "relu" ]))
    // Now we flatten the output from the 2D filters into a 1D vector to prepare
    // it for input into our last layer. This is common practice when feeding
    // higher dimensional data to a final classification output layer.
    model?add (tf?layers?flatten (createObj []))
    model?add (tf?layers?dense (createObj [ "units" ==> 64
                                            "activation" ==> "relu" ]))
    // Our last layer is a dense layer which has 10 output units, one for each
    // output class (i.e. 0, 1, 2, 3, 4, 5, 6, 7, 8, 9). Here the classes actually
    // represent numbers, but it's the same idea if you had classes that
    // represented other entities like dogs and cats (two output classes: 0, 1).
    // We use the softmax function as the activation for the output layer as it
    // creates a probability distribution over our 10 classes so their output
    // values sum to 1.
    model?add (tf?layers?dense (createObj [ "units" ==> 10
                                            "activation" ==> "softmax" ]))
    model

(**
* Creates a model consisting of only flatten, dense and dropout layers.
*
* The model create here has approximately the same number of parameters
* (~31k) as the convnet created by `createConvModel()`, but is
* expected to show a significantly worse accuracy after training, due to the
* fact that it doesn't utilize the spatial information as the convnet does.
*
* This is for comparison with the convolutional network above.
*
* @returns {tf.Model} An instance of tf.Model.
*)
let createDenseModel() =
    let model = tf?sequential ()
    model?add (tf?layers?flatten (createObj
                                      [ "inputShape"
                                        ==> Array.Create(ImageHeight, ImageWidth, 1) ]))
    model?add (tf?layers?dense (createObj [ "units" ==> 42
                                            "activation" ==> "relu" ]))
    model?add (tf?layers?dense (createObj [ "units" ==> 10
                                            "activation" ==> "softmax" ]))
    model


let showPrediction model = ""
