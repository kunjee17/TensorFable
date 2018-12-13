namespace TrainingParameters

open Fable.Core

module Types =
    [<StringEnum>]
    type ModelType =
        | [<CompiledName("ConvNet")>] ConvNet
        | [<CompiledName("DenseNet")>] DenseNet
        static member FromString =
            function
            | "ConvNet" -> ConvNet
            | "DenseNet" -> DenseNet
            | _ -> ConvNet

    type Model =
        { SelectedModeltype : ModelType
          Epochs : int }

    type Msg =
        | EpoachChange of int
        | SelectedModelTypeChange of ModelType
        | LoadAndTrain

module State =
    open Elmish
    open Types

    let init() =
        { SelectedModeltype = ConvNet
          Epochs = 3 }, Cmd.none

    let update msg model =
        match msg with
        | EpoachChange i -> { model with Epochs = i }, Cmd.none
        | SelectedModelTypeChange m ->
            { model with SelectedModeltype = m }, Cmd.none
        | LoadAndTrain -> model, Cmd.none //It will start trainign in another component

module View =
    open Elmish
    open Elmish.React
    open Fable.Helpers.React
    open Fable.Helpers.React.Props
    open Types
    open JsInterop

    let root (model : Model) dispatch =
        section []
            [ p [ Class "section-head" ] [ str "Training Parameters" ]

              div []
                  [ label [] [ str "Model Type:" ]

                    select [ Id "model-type"
                             OnChange(fun ev ->
                                 ev.target?value
                                 |> ModelType.FromString
                                 |> SelectedModelTypeChange
                                 |> dispatch) ]
                        [ option [ Value(ConvNet.ToString()) ]
                              [ str (ConvNet.ToString()) ]

                          option [ Value(DenseNet.ToString()) ]
                              [ str (DenseNet.ToString()) ] ] ]
              div [] [ label [] [ str "# of training epochs:" ]
                       input [ Id "train-epochs"
                               DefaultValue(model.Epochs.ToString())
                               OnChange(fun ev ->
                                   ev.target?value
                                   |> int
                                   |> EpoachChange
                                   |> dispatch) ] ]

              button [ Id "train"
                       OnClick(fun _ -> LoadAndTrain |> dispatch) ]
                  [ str "Load Data and Train Model" ] ]
