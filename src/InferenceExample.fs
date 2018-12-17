namespace InferenceExample

open Fable.Core
open JsInterop

module Types =
    type Model =
        { Predictions : int []
          Labels : int []
          Batch : int }

module State =
    open Elmish
    open Types

    let init() : Model =
        { Predictions = [||]
          Labels = [||]
          Batch = 5 }

module View =
    open Elmish
    open Elmish.React
    open Fable.Helpers.React
    open Fable.Helpers.React.Props
    open Types

    let showResult correct prediction =
        div [ ClassName "pred-container" ]
            [ div [ ClassName(sprintf "pred %s" (if correct then "pred-correct"
                                                 else "pred-incorrect")) ]
                  [ str (sprintf "pred: %i" prediction) ]
              canvas [ ClassName "prediction-canvas" ] [] ]

    //canvas
    //draw image function
    let root (model : Model) =
        section [] [ p [ Class "section-head" ] [ str "Inference Examples" ]
                     div [ Id "images" ] [ for i = 0 to model.Batch do
                                               yield showResult true 0 ] ]
