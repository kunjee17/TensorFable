module App

open Elmish
open Elmish.React
open Fable.Helpers.React
open Fable.Helpers.React.Props

// MODEL
type Model =
    { TfTitle : TfTitle.Types.Model
      Description : Description.Types.Model
      TrainingParameters : TrainingParameters.Types.Model
      TrainingProgress : TrainingProgress.Types.Model
      InferenceExample : InferenceExample.Types.Model }

type Msg =
    | TrainingParametersMsg of TrainingParameters.Types.Msg
    | TrainingProgressMsg of TrainingProgress.Types.Msg

let init() =
    let tfTitle = TfTitle.State.init()
    let description = Description.State.init()
    let trainingParameters, trainingParametersCmd =
        TrainingParameters.State.init()
    let trainingProgress, trainingProgressCmd = TrainingProgress.State.init()
    let inferenceExample = InferenceExample.State.init()
    { TfTitle = tfTitle
      Description = description
      TrainingParameters = trainingParameters
      TrainingProgress = trainingProgress
      InferenceExample = inferenceExample },
    Cmd.batch [ Cmd.map TrainingParametersMsg trainingParametersCmd
                Cmd.map TrainingProgressMsg trainingProgressCmd ]

// UPDATE
let update (msg : Msg) (model : Model) =
    match msg with
    | TrainingParametersMsg m ->
        let trainingParameters, trainingParametersCmd =
            TrainingParameters.State.update m model.TrainingParameters
        let res, resCmd =
            { model with TrainingParameters = trainingParameters },
            Cmd.map TrainingParametersMsg trainingParametersCmd
        match m with
        | TrainingParameters.Types.Msg.LoadAndTrain ->
            let pass =
                TrainingProgress.Types.Msg.StartTraining
                    (model.TrainingParameters.SelectedModeltype,
                     model.TrainingParameters.Epochs)
            res,
            Cmd.batch [ resCmd
                        Cmd.map TrainingProgressMsg (Cmd.ofMsg pass) ]
        | _ -> res, resCmd
    | TrainingProgressMsg m ->
        let trainingProgress, trainingProgressCmd =
            TrainingProgress.State.update m model.TrainingProgress
        { model with TrainingProgress = trainingProgress },
        Cmd.map TrainingProgressMsg trainingProgressCmd

// VIEW (rendered with React)
let view (model : Model) dispatch =
    div [ Class "tfjs-example-container" ]
        [ TfTitle.View.root model.TfTitle
          Description.View.root model.Description

          TrainingParameters.View.root model.TrainingParameters
              (TrainingParametersMsg >> dispatch)
          TrainingProgress.View.root model.TrainingProgress
          InferenceExample.View.root model.InferenceExample ]

// App
Program.mkProgram init update view
|> Program.withReact "elmish-app"
|> Program.withConsoleTrace
|> Program.run
