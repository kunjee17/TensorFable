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

type Msg = TrainingParametersMsg of TrainingParameters.Types.Msg

let init() =
    let tfTitle = TfTitle.State.init()
    let description = Description.State.init()
    let trainingParameters, trainingParametersCmd =
        TrainingParameters.State.init()
    let trainingProgress = TrainingProgress.State.init()
    let inferenceExample = InferenceExample.State.init()
    { TfTitle = tfTitle
      Description = description
      TrainingParameters = trainingParameters
      TrainingProgress = trainingProgress
      InferenceExample = inferenceExample }, Cmd.batch [ trainingParametersCmd ]

// UPDATE
let update (msg : Msg) (model : Model) =
    match msg with
    | TrainingParametersMsg m ->
        let trainingParameters, trainingParametersCmd =
            TrainingParameters.State.update m model.TrainingParameters
        { model with TrainingParameters = trainingParameters },
        Cmd.map TrainingParametersMsg trainingParametersCmd

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
