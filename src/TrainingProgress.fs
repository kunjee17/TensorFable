namespace TrainingProgress

module Types =
    type Model =
        int

module State =
    open Elmish
    open Types

    let init() : Model =
        0

module View =
    open Elmish
    open Elmish.React
    open Fable.Helpers.React
    open Fable.Helpers.React.Props
    open Types

    let root (model : Model) =
        section []
              [ p [ Class "section-head" ] [ str "Training Progress" ]
                p [ Id "status" ] []
                p [ Id "message" ] []

                div [ Id "stats" ]
                    [ div [ Class "canvases" ] [ label [ Id "loss-label" ] []
                                                 div [ Id "loss-canvas" ] [] ]

                      div [ Class "canvases" ]
                          [ label [ Id "accuracy-label" ] []
                            div [ Id "accuracy-canvas" ] [] ] ] ]
