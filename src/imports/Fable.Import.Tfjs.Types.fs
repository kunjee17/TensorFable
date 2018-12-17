namespace Fable.Import.Tfjs

module rec Types =
    open System
    open Fable.Core
    open Fable.Import.JS

    [<AllowNullLiteral>]
    type IExports =
        abstract upcastType : typeA:DataType * typeB:DataType -> DataType
        abstract sumOutType : ``type``:DataType -> DataType

    [<AllowNullLiteral>]
    type ShapeMap =
        abstract R0 : ResizeArray<float> with get, set
        abstract R1 : float with get, set
        abstract R2 : float * float with get, set
        abstract R3 : float * float * float with get, set
        abstract R4 : float * float * float * float with get, set
        abstract R5 : float * float * float * float * float with get, set
        abstract R6 : float * float * float * float * float * float with get, set

    [<AllowNullLiteral>]
    type DataTypeMap =
        abstract float32 : Float32Array with get, set
        abstract int32 : Int32Array with get, set
        abstract bool : Uint8Array with get, set
        abstract complex64 : Float32Array with get, set
        abstract string : ResizeArray<string> with get, set

    [<AllowNullLiteral>]
    type SingleValueMap =
        abstract bool : bool with get, set
        abstract int32 : float with get, set
        abstract float32 : float with get, set
        abstract complex64 : float with get, set
        abstract string : string with get, set

    type DataType = obj

    [<StringEnum; RequireQualifiedAccess>]
    type NumericDataType =
        | Float32
        | Int32
        | Bool
        | Complex64

    type TypedArray = U3<Float32Array, Int32Array, Uint8Array>

    [<RequireQualifiedAccess; CompilationRepresentation(CompilationRepresentationFlags.ModuleSuffix)>]
    module TypedArray =
        let ofFloat32Array v : TypedArray = v |> U3.Case1

        let isFloat32Array (v : TypedArray) =
            match v with
            | U3.Case1 _ -> true
            | _ -> false

        let asFloat32Array (v : TypedArray) =
            match v with
            | U3.Case1 o -> Some o
            | _ -> None

        let ofInt32Array v : TypedArray = v |> U3.Case2

        let isInt32Array (v : TypedArray) =
            match v with
            | U3.Case2 _ -> true
            | _ -> false

        let asInt32Array (v : TypedArray) =
            match v with
            | U3.Case2 o -> Some o
            | _ -> None

        let ofUint8Array v : TypedArray = v |> U3.Case3

        let isUint8Array (v : TypedArray) =
            match v with
            | U3.Case3 _ -> true
            | _ -> false

        let asUint8Array (v : TypedArray) =
            match v with
            | U3.Case3 o -> Some o
            | _ -> None

    type DataValues = DataTypeMap

    [<StringEnum; RequireQualifiedAccess>]
    type Rank =
        | [<CompiledName"R0">] R0
        | [<CompiledName"R1">] R1
        | [<CompiledName"R2">] R2
        | [<CompiledName"R3">] R3
        | [<CompiledName"R4">] R4
        | [<CompiledName"R5">] R5
        | [<CompiledName"R6">] R6

    type FlatVector = U3<ResizeArray<bool>, ResizeArray<float>, TypedArray>

    [<RequireQualifiedAccess; CompilationRepresentation(CompilationRepresentationFlags.ModuleSuffix)>]
    module FlatVector =
        let ofBoolArray v : FlatVector = v |> U3.Case1

        let isBoolArray (v : FlatVector) =
            match v with
            | U3.Case1 _ -> true
            | _ -> false

        let asBoolArray (v : FlatVector) =
            match v with
            | U3.Case1 o -> Some o
            | _ -> None

        let ofFloatArray v : FlatVector = v |> U3.Case2

        let isFloatArray (v : FlatVector) =
            match v with
            | U3.Case2 _ -> true
            | _ -> false

        let asFloatArray (v : FlatVector) =
            match v with
            | U3.Case2 o -> Some o
            | _ -> None

        let ofTypedArray v : FlatVector = v |> U3.Case3

        let isTypedArray (v : FlatVector) =
            match v with
            | U3.Case3 _ -> true
            | _ -> false

        let asTypedArray (v : FlatVector) =
            match v with
            | U3.Case3 o -> Some o
            | _ -> None

    type RegularArray<'T> = U6<ResizeArray<'T>, ResizeArray<ResizeArray<'T>>, ResizeArray<ResizeArray<ResizeArray<'T>>>, ResizeArray<ResizeArray<ResizeArray<ResizeArray<'T>>>>, ResizeArray<ResizeArray<ResizeArray<ResizeArray<ResizeArray<'T>>>>>, ResizeArray<ResizeArray<ResizeArray<ResizeArray<ResizeArray<ResizeArray<'T>>>>>>>

    [<RequireQualifiedAccess; CompilationRepresentation(CompilationRepresentationFlags.ModuleSuffix)>]
    module RegularArray =
        let ofTArray v : RegularArray<'T> = v |> U6.Case1

        let isTArray (v : RegularArray<'T>) =
            match v with
            | U6.Case1 _ -> true
            | _ -> false

        let asTArray (v : RegularArray<'T>) =
            match v with
            | U6.Case1 o -> Some o
            | _ -> None

        let ofTArrayArray v : RegularArray<'T> = v |> U6.Case2

        let isTArrayArray (v : RegularArray<'T>) =
            match v with
            | U6.Case2 _ -> true
            | _ -> false

        let asTArrayArray (v : RegularArray<'T>) =
            match v with
            | U6.Case2 o -> Some o
            | _ -> None

        let ofTArrayArrayArray v : RegularArray<'T> = v |> U6.Case3

        let isTArrayArrayArray (v : RegularArray<'T>) =
            match v with
            | U6.Case3 _ -> true
            | _ -> false

        let asTArrayArrayArray (v : RegularArray<'T>) =
            match v with
            | U6.Case3 o -> Some o
            | _ -> None

        let ofTArrayArrayArrayArray v : RegularArray<'T> = v |> U6.Case4

        let isTArrayArrayArrayArray (v : RegularArray<'T>) =
            match v with
            | U6.Case4 _ -> true
            | _ -> false

        let asTArrayArrayArrayArray (v : RegularArray<'T>) =
            match v with
            | U6.Case4 o -> Some o
            | _ -> None

        let ofTArrayArrayArrayArrayArray v : RegularArray<'T> = v |> U6.Case5

        let isTArrayArrayArrayArrayArray (v : RegularArray<'T>) =
            match v with
            | U6.Case5 _ -> true
            | _ -> false

        let asTArrayArrayArrayArrayArray (v : RegularArray<'T>) =
            match v with
            | U6.Case5 o -> Some o
            | _ -> None

        let ofTArrayArrayArrayArrayArrayArray v : RegularArray<'T> =
            v |> U6.Case6

        let isTArrayArrayArrayArrayArrayArray (v : RegularArray<'T>) =
            match v with
            | U6.Case6 _ -> true
            | _ -> false

        let asTArrayArrayArrayArrayArrayArray (v : RegularArray<'T>) =
            match v with
            | U6.Case6 o -> Some o
            | _ -> None

    [<AllowNullLiteral>]
    type RecursiveArray<'T> =
        [<Emit"$0[$1]{{=$2}}">]
        abstract Item : index:float -> U2<'T, RecursiveArray<'T>> with get, set

    type TensorLike = U7<TypedArray, float, bool, string, RegularArray<U3<float, ResizeArray<float>, TypedArray>>, RegularArray<bool>, RegularArray<string>>

    [<RequireQualifiedAccess; CompilationRepresentation(CompilationRepresentationFlags.ModuleSuffix)>]
    module TensorLike =
        let ofTypedArray v : TensorLike = v |> U7.Case1

        let isTypedArray (v : TensorLike) =
            match v with
            | U7.Case1 _ -> true
            | _ -> false

        let asTypedArray (v : TensorLike) =
            match v with
            | U7.Case1 o -> Some o
            | _ -> None

        let ofFloat v : TensorLike = v |> U7.Case2

        let isFloat (v : TensorLike) =
            match v with
            | U7.Case2 _ -> true
            | _ -> false

        let asFloat (v : TensorLike) =
            match v with
            | U7.Case2 o -> Some o
            | _ -> None

        let ofBool v : TensorLike = v |> U7.Case3

        let isBool (v : TensorLike) =
            match v with
            | U7.Case3 _ -> true
            | _ -> false

        let asBool (v : TensorLike) =
            match v with
            | U7.Case3 o -> Some o
            | _ -> None

        let ofString v : TensorLike = v |> U7.Case4

        let isString (v : TensorLike) =
            match v with
            | U7.Case4 _ -> true
            | _ -> false

        let asString (v : TensorLike) =
            match v with
            | U7.Case4 o -> Some o
            | _ -> None

        let ofRegularArray v : TensorLike = v |> U7.Case5

        let isRegularArray (v : TensorLike) =
            match v with
            | U7.Case5 _ -> true
            | _ -> false

        let asRegularArray (v : TensorLike) =
            match v with
            | U7.Case5 o -> Some o
            | _ -> None

        // let ofRegularArray v : TensorLike = v |> U7.Case6

        // let isRegularArray (v : TensorLike) =
        //     match v with
        //     | U7.Case6 _ -> true
        //     | _ -> false

        // let asRegularArray (v : TensorLike) =
        //     match v with
        //     | U7.Case6 o -> Some o
        //     | _ -> None

        // let ofRegularArray v : TensorLike = v |> U7.Case7

        // let isRegularArray (v : TensorLike) =
        //     match v with
        //     | U7.Case7 _ -> true
        //     | _ -> false

        // let asRegularArray (v : TensorLike) =
        //     match v with
        //     | U7.Case7 o -> Some o
        //     | _ -> None

    type TensorLike1D = U4<TypedArray, ResizeArray<float>, ResizeArray<bool>, ResizeArray<string>>

    [<RequireQualifiedAccess; CompilationRepresentation(CompilationRepresentationFlags.ModuleSuffix)>]
    module TensorLike1D =
        let ofTypedArray v : TensorLike1D = v |> U4.Case1

        let isTypedArray (v : TensorLike1D) =
            match v with
            | U4.Case1 _ -> true
            | _ -> false

        let asTypedArray (v : TensorLike1D) =
            match v with
            | U4.Case1 o -> Some o
            | _ -> None

        let ofFloatArray v : TensorLike1D = v |> U4.Case2

        let isFloatArray (v : TensorLike1D) =
            match v with
            | U4.Case2 _ -> true
            | _ -> false

        let asFloatArray (v : TensorLike1D) =
            match v with
            | U4.Case2 o -> Some o
            | _ -> None

        let ofBoolArray v : TensorLike1D = v |> U4.Case3

        let isBoolArray (v : TensorLike1D) =
            match v with
            | U4.Case3 _ -> true
            | _ -> false

        let asBoolArray (v : TensorLike1D) =
            match v with
            | U4.Case3 o -> Some o
            | _ -> None

        let ofStringArray v : TensorLike1D = v |> U4.Case4

        let isStringArray (v : TensorLike1D) =
            match v with
            | U4.Case4 _ -> true
            | _ -> false

        let asStringArray (v : TensorLike1D) =
            match v with
            | U4.Case4 o -> Some o
            | _ -> None

    type TensorLike2D = U7<TypedArray, ResizeArray<float>, ResizeArray<ResizeArray<float>>, ResizeArray<bool>, ResizeArray<ResizeArray<bool>>, ResizeArray<string>, ResizeArray<ResizeArray<string>>>

    [<RequireQualifiedAccess; CompilationRepresentation(CompilationRepresentationFlags.ModuleSuffix)>]
    module TensorLike2D =
        let ofTypedArray v : TensorLike2D = v |> U7.Case1

        let isTypedArray (v : TensorLike2D) =
            match v with
            | U7.Case1 _ -> true
            | _ -> false

        let asTypedArray (v : TensorLike2D) =
            match v with
            | U7.Case1 o -> Some o
            | _ -> None

        let ofFloatArray v : TensorLike2D = v |> U7.Case2

        let isFloatArray (v : TensorLike2D) =
            match v with
            | U7.Case2 _ -> true
            | _ -> false

        let asFloatArray (v : TensorLike2D) =
            match v with
            | U7.Case2 o -> Some o
            | _ -> None

        let ofFloatArrayArray v : TensorLike2D = v |> U7.Case3

        let isFloatArrayArray (v : TensorLike2D) =
            match v with
            | U7.Case3 _ -> true
            | _ -> false

        let asFloatArrayArray (v : TensorLike2D) =
            match v with
            | U7.Case3 o -> Some o
            | _ -> None

        let ofBoolArray v : TensorLike2D = v |> U7.Case4

        let isBoolArray (v : TensorLike2D) =
            match v with
            | U7.Case4 _ -> true
            | _ -> false

        let asBoolArray (v : TensorLike2D) =
            match v with
            | U7.Case4 o -> Some o
            | _ -> None

        let ofBoolArrayArray v : TensorLike2D = v |> U7.Case5

        let isBoolArrayArray (v : TensorLike2D) =
            match v with
            | U7.Case5 _ -> true
            | _ -> false

        let asBoolArrayArray (v : TensorLike2D) =
            match v with
            | U7.Case5 o -> Some o
            | _ -> None

        let ofStringArray v : TensorLike2D = v |> U7.Case6

        let isStringArray (v : TensorLike2D) =
            match v with
            | U7.Case6 _ -> true
            | _ -> false

        let asStringArray (v : TensorLike2D) =
            match v with
            | U7.Case6 o -> Some o
            | _ -> None

        let ofStringArrayArray v : TensorLike2D = v |> U7.Case7

        let isStringArrayArray (v : TensorLike2D) =
            match v with
            | U7.Case7 _ -> true
            | _ -> false

        let asStringArrayArray (v : TensorLike2D) =
            match v with
            | U7.Case7 o -> Some o
            | _ -> None

    type TensorLike3D = U7<TypedArray, ResizeArray<float>, ResizeArray<ResizeArray<ResizeArray<float>>>, ResizeArray<bool>, ResizeArray<ResizeArray<ResizeArray<bool>>>, ResizeArray<string>, ResizeArray<ResizeArray<ResizeArray<string>>>>

    [<RequireQualifiedAccess; CompilationRepresentation(CompilationRepresentationFlags.ModuleSuffix)>]
    module TensorLike3D =
        let ofTypedArray v : TensorLike3D = v |> U7.Case1

        let isTypedArray (v : TensorLike3D) =
            match v with
            | U7.Case1 _ -> true
            | _ -> false

        let asTypedArray (v : TensorLike3D) =
            match v with
            | U7.Case1 o -> Some o
            | _ -> None

        let ofFloatArray v : TensorLike3D = v |> U7.Case2

        let isFloatArray (v : TensorLike3D) =
            match v with
            | U7.Case2 _ -> true
            | _ -> false

        let asFloatArray (v : TensorLike3D) =
            match v with
            | U7.Case2 o -> Some o
            | _ -> None

        let ofFloatArrayArrayArray v : TensorLike3D = v |> U7.Case3

        let isFloatArrayArrayArray (v : TensorLike3D) =
            match v with
            | U7.Case3 _ -> true
            | _ -> false

        let asFloatArrayArrayArray (v : TensorLike3D) =
            match v with
            | U7.Case3 o -> Some o
            | _ -> None

        let ofBoolArray v : TensorLike3D = v |> U7.Case4

        let isBoolArray (v : TensorLike3D) =
            match v with
            | U7.Case4 _ -> true
            | _ -> false

        let asBoolArray (v : TensorLike3D) =
            match v with
            | U7.Case4 o -> Some o
            | _ -> None

        let ofBoolArrayArrayArray v : TensorLike3D = v |> U7.Case5

        let isBoolArrayArrayArray (v : TensorLike3D) =
            match v with
            | U7.Case5 _ -> true
            | _ -> false

        let asBoolArrayArrayArray (v : TensorLike3D) =
            match v with
            | U7.Case5 o -> Some o
            | _ -> None

        let ofStringArray v : TensorLike3D = v |> U7.Case6

        let isStringArray (v : TensorLike3D) =
            match v with
            | U7.Case6 _ -> true
            | _ -> false

        let asStringArray (v : TensorLike3D) =
            match v with
            | U7.Case6 o -> Some o
            | _ -> None

        let ofStringArrayArrayArray v : TensorLike3D = v |> U7.Case7

        let isStringArrayArrayArray (v : TensorLike3D) =
            match v with
            | U7.Case7 _ -> true
            | _ -> false

        let asStringArrayArrayArray (v : TensorLike3D) =
            match v with
            | U7.Case7 o -> Some o
            | _ -> None

    type TensorLike4D = U7<TypedArray, ResizeArray<float>, ResizeArray<ResizeArray<ResizeArray<ResizeArray<float>>>>, ResizeArray<bool>, ResizeArray<ResizeArray<ResizeArray<ResizeArray<bool>>>>, ResizeArray<string>, ResizeArray<ResizeArray<ResizeArray<ResizeArray<string>>>>>

    [<RequireQualifiedAccess; CompilationRepresentation(CompilationRepresentationFlags.ModuleSuffix)>]
    module TensorLike4D =
        let ofTypedArray v : TensorLike4D = v |> U7.Case1

        let isTypedArray (v : TensorLike4D) =
            match v with
            | U7.Case1 _ -> true
            | _ -> false

        let asTypedArray (v : TensorLike4D) =
            match v with
            | U7.Case1 o -> Some o
            | _ -> None

        let ofFloatArray v : TensorLike4D = v |> U7.Case2

        let isFloatArray (v : TensorLike4D) =
            match v with
            | U7.Case2 _ -> true
            | _ -> false

        let asFloatArray (v : TensorLike4D) =
            match v with
            | U7.Case2 o -> Some o
            | _ -> None

        let ofFloatArrayArrayArrayArray v : TensorLike4D = v |> U7.Case3

        let isFloatArrayArrayArrayArray (v : TensorLike4D) =
            match v with
            | U7.Case3 _ -> true
            | _ -> false

        let asFloatArrayArrayArrayArray (v : TensorLike4D) =
            match v with
            | U7.Case3 o -> Some o
            | _ -> None

        let ofBoolArray v : TensorLike4D = v |> U7.Case4

        let isBoolArray (v : TensorLike4D) =
            match v with
            | U7.Case4 _ -> true
            | _ -> false

        let asBoolArray (v : TensorLike4D) =
            match v with
            | U7.Case4 o -> Some o
            | _ -> None

        let ofBoolArrayArrayArrayArray v : TensorLike4D = v |> U7.Case5

        let isBoolArrayArrayArrayArray (v : TensorLike4D) =
            match v with
            | U7.Case5 _ -> true
            | _ -> false

        let asBoolArrayArrayArrayArray (v : TensorLike4D) =
            match v with
            | U7.Case5 o -> Some o
            | _ -> None

        let ofStringArray v : TensorLike4D = v |> U7.Case6

        let isStringArray (v : TensorLike4D) =
            match v with
            | U7.Case6 _ -> true
            | _ -> false

        let asStringArray (v : TensorLike4D) =
            match v with
            | U7.Case6 o -> Some o
            | _ -> None

        let ofStringArrayArrayArrayArray v : TensorLike4D = v |> U7.Case7

        let isStringArrayArrayArrayArray (v : TensorLike4D) =
            match v with
            | U7.Case7 _ -> true
            | _ -> false

        let asStringArrayArrayArrayArray (v : TensorLike4D) =
            match v with
            | U7.Case7 o -> Some o
            | _ -> None

    type TensorLike5D = U7<TypedArray, ResizeArray<float>, ResizeArray<ResizeArray<ResizeArray<ResizeArray<ResizeArray<float>>>>>, ResizeArray<bool>, ResizeArray<ResizeArray<ResizeArray<ResizeArray<ResizeArray<bool>>>>>, ResizeArray<string>, ResizeArray<ResizeArray<ResizeArray<ResizeArray<ResizeArray<string>>>>>>

    [<RequireQualifiedAccess; CompilationRepresentation(CompilationRepresentationFlags.ModuleSuffix)>]
    module TensorLike5D =
        let ofTypedArray v : TensorLike5D = v |> U7.Case1

        let isTypedArray (v : TensorLike5D) =
            match v with
            | U7.Case1 _ -> true
            | _ -> false

        let asTypedArray (v : TensorLike5D) =
            match v with
            | U7.Case1 o -> Some o
            | _ -> None

        let ofFloatArray v : TensorLike5D = v |> U7.Case2

        let isFloatArray (v : TensorLike5D) =
            match v with
            | U7.Case2 _ -> true
            | _ -> false

        let asFloatArray (v : TensorLike5D) =
            match v with
            | U7.Case2 o -> Some o
            | _ -> None

        let ofFloatArrayArrayArrayArrayArray v : TensorLike5D = v |> U7.Case3

        let isFloatArrayArrayArrayArrayArray (v : TensorLike5D) =
            match v with
            | U7.Case3 _ -> true
            | _ -> false

        let asFloatArrayArrayArrayArrayArray (v : TensorLike5D) =
            match v with
            | U7.Case3 o -> Some o
            | _ -> None

        let ofBoolArray v : TensorLike5D = v |> U7.Case4

        let isBoolArray (v : TensorLike5D) =
            match v with
            | U7.Case4 _ -> true
            | _ -> false

        let asBoolArray (v : TensorLike5D) =
            match v with
            | U7.Case4 o -> Some o
            | _ -> None

        let ofBoolArrayArrayArrayArrayArray v : TensorLike5D = v |> U7.Case5

        let isBoolArrayArrayArrayArrayArray (v : TensorLike5D) =
            match v with
            | U7.Case5 _ -> true
            | _ -> false

        let asBoolArrayArrayArrayArrayArray (v : TensorLike5D) =
            match v with
            | U7.Case5 o -> Some o
            | _ -> None

        let ofStringArray v : TensorLike5D = v |> U7.Case6

        let isStringArray (v : TensorLike5D) =
            match v with
            | U7.Case6 _ -> true
            | _ -> false

        let asStringArray (v : TensorLike5D) =
            match v with
            | U7.Case6 o -> Some o
            | _ -> None

        let ofStringArrayArrayArrayArrayArray v : TensorLike5D = v |> U7.Case7

        let isStringArrayArrayArrayArrayArray (v : TensorLike5D) =
            match v with
            | U7.Case7 _ -> true
            | _ -> false

        let asStringArrayArrayArrayArrayArray (v : TensorLike5D) =
            match v with
            | U7.Case7 o -> Some o
            | _ -> None

    type TensorLike6D = U7<TypedArray, ResizeArray<float>, ResizeArray<ResizeArray<ResizeArray<ResizeArray<ResizeArray<ResizeArray<float>>>>>>, ResizeArray<bool>, ResizeArray<ResizeArray<ResizeArray<ResizeArray<ResizeArray<ResizeArray<bool>>>>>>, ResizeArray<string>, ResizeArray<ResizeArray<ResizeArray<ResizeArray<ResizeArray<ResizeArray<string>>>>>>>

    [<RequireQualifiedAccess; CompilationRepresentation(CompilationRepresentationFlags.ModuleSuffix)>]
    module TensorLike6D =
        let ofTypedArray v : TensorLike6D = v |> U7.Case1

        let isTypedArray (v : TensorLike6D) =
            match v with
            | U7.Case1 _ -> true
            | _ -> false

        let asTypedArray (v : TensorLike6D) =
            match v with
            | U7.Case1 o -> Some o
            | _ -> None

        let ofFloatArray v : TensorLike6D = v |> U7.Case2

        let isFloatArray (v : TensorLike6D) =
            match v with
            | U7.Case2 _ -> true
            | _ -> false

        let asFloatArray (v : TensorLike6D) =
            match v with
            | U7.Case2 o -> Some o
            | _ -> None

        let ofFloatArrayArrayArrayArrayArrayArray v : TensorLike6D =
            v |> U7.Case3

        let isFloatArrayArrayArrayArrayArrayArray (v : TensorLike6D) =
            match v with
            | U7.Case3 _ -> true
            | _ -> false

        let asFloatArrayArrayArrayArrayArrayArray (v : TensorLike6D) =
            match v with
            | U7.Case3 o -> Some o
            | _ -> None

        let ofBoolArray v : TensorLike6D = v |> U7.Case4

        let isBoolArray (v : TensorLike6D) =
            match v with
            | U7.Case4 _ -> true
            | _ -> false

        let asBoolArray (v : TensorLike6D) =
            match v with
            | U7.Case4 o -> Some o
            | _ -> None

        let ofBoolArrayArrayArrayArrayArrayArray v : TensorLike6D =
            v |> U7.Case5

        let isBoolArrayArrayArrayArrayArrayArray (v : TensorLike6D) =
            match v with
            | U7.Case5 _ -> true
            | _ -> false

        let asBoolArrayArrayArrayArrayArrayArray (v : TensorLike6D) =
            match v with
            | U7.Case5 o -> Some o
            | _ -> None

        let ofStringArray v : TensorLike6D = v |> U7.Case6

        let isStringArray (v : TensorLike6D) =
            match v with
            | U7.Case6 _ -> true
            | _ -> false

        let asStringArray (v : TensorLike6D) =
            match v with
            | U7.Case6 o -> Some o
            | _ -> None

        let ofStringArrayArrayArrayArrayArrayArray v : TensorLike6D =
            v |> U7.Case7

        let isStringArrayArrayArrayArrayArrayArray (v : TensorLike6D) =
            match v with
            | U7.Case7 _ -> true
            | _ -> false

        let asStringArrayArrayArrayArrayArrayArray (v : TensorLike6D) =
            match v with
            | U7.Case7 o -> Some o
            | _ -> None
