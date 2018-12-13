namespace Description

module Types =
    type Model =
        { Head : string
          Para1 : string
          Para2 : string }

module State =
    open Elmish
    open Types

    let init() =
        { Head = "Description"
          Para1 =
              "This examples lets you train a handwritten digit recognizer using either a Convolutional Neural Network
          (also known as a ConvNet or CNN) or a Fully Connected Neural Network (also known as a DenseNet)."
          Para2 = "The MNIST dataset is used as training data." }

module View =
    open Elmish
    open Elmish.React
    open Fable.Helpers.React
    open Fable.Helpers.React.Props
    open Types

    let root (model : Model) =
        section [] [ p [ Class "section-head" ] [ str model.Head ]
                     p [] [ str model.Para1 ]
                     p [] [ str model.Para2 ] ]
