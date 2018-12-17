module CommonTypes

open Fable.Core

[<StringEnum>]
type ModelType =
    | [<CompiledName("ConvNet")>] ConvNet
    | [<CompiledName("DenseNet")>] DenseNet
    static member FromString =
        function
        | "ConvNet" -> ConvNet
        | "DenseNet" -> DenseNet
        | _ -> ConvNet
