namespace InferenceExample

module Types =
    type Model = int

module State =
    open Elmish
    open Types

    let init() : Model = 0

module View =
    open Elmish
    open Elmish.React
    open Fable.Helpers.React
    open Fable.Helpers.React.Props
    open Types

    let root (model : Model) =
        section [] [ p [ Class "section-head" ] [ str "Inference Examples" ]
                     div [ Id "images" ] [] ]
