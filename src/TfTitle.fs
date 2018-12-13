namespace TfTitle

module Types =
    type Model =
        { Title : string
          SubTitle : string }

module State =
    open Elmish
    open Types

    let init() =
        { Title = "TensorFlow.js: Digit Recognizer with Layers"
          SubTitle =
              "Train a model to recognize handwritten digits from the MNIST database using the tf.layers api." }

module View =
    open Elmish
    open Elmish.React
    open Fable.Helpers.React
    open Fable.Helpers.React.Props
    open Types

    let root (model : Model) =
        section [ Class "title-area" ]
            [ h1 [] [ str model.Title ]
              p [ Class "subtitle" ] [ str model.SubTitle ] ]
