namespace Fable.Import.Tfjs

module rec Tensor =
    open System
    open Fable.Core
    open Fable.Import.JS
    open Types

    [<AllowNullLiteral>]
    type IExports =
        abstract TensorBuffer : TensorBufferStatic
        abstract setTensorTracker : fn:(unit -> TensorTracker) -> unit
        abstract setOpHandler : handler:OpHandler -> unit
        abstract Tensor : TensorStatic
        abstract Variable : VariableStatic

    [<AllowNullLiteral>]
    type TensorData<'D> =
        abstract dataId : DataId option with get, set
        abstract values : DataTypeMap option with get, set

    type TensorBuffer<'D> = TensorBuffer<obj, 'D>

    [<AllowNullLiteral>]
    type TensorBuffer<'R, 'D> =
        abstract dtype : 'D with get, set
        abstract size : float with get, set
        abstract shape : ShapeMap with get, set
        abstract strides : ResizeArray<float> with get, set
        abstract values : DataTypeMap with get, set
        abstract set : value:SingleValueMap * [<ParamArray>] locs:ResizeArray<float>
         -> unit
        abstract get : [<ParamArray>] locs:ResizeArray<float> -> SingleValueMap
        abstract locToIndex : locs:ResizeArray<float> -> float
        abstract indexToLoc : index:float -> ResizeArray<float>
        abstract rank : float
        abstract toTensor : unit -> Tensor<'R>

    [<AllowNullLiteral>]
    type TensorBufferStatic =
        [<Emit"new $0($1...)">]
        abstract Create : shape:ShapeMap * dtype:'D * ?values:DataTypeMap
         -> TensorBuffer<'R, 'D>

    [<AllowNullLiteral>]
    type TensorTracker =
        abstract registerTensor : t:Tensor -> unit
        abstract disposeTensor : t:Tensor -> unit
        abstract write : dataId:DataId * values:DataValues -> unit
        abstract read : dataId:DataId -> Promise<DataValues>
        abstract readSync : dataId:DataId -> DataValues
        abstract registerVariable : v:Variable -> unit
        abstract nextTensorId : unit -> float
        abstract nextVariableId : unit -> float

    [<AllowNullLiteral>]
    type OpHandler =
        abstract cast : x:'T * dtype:DataType -> 'T
        abstract buffer : shape:ShapeMap * dtype:'D * ?values:DataTypeMap
         -> TensorBuffer<'R, 'D>
        abstract print : x:'T * verbose:bool -> unit
        abstract reshape : x:Tensor * shape:ShapeMap -> Tensor<'R2>
        abstract expandDims : x:Tensor * axis:float -> Tensor<'R2>
        abstract cumsum : x:Tensor * axis:float * exclusive:bool * reverse:bool
         -> 'T
        abstract squeeze : x:Tensor * ?axis:ResizeArray<float> -> 'T
        abstract clone : x:'T -> 'T
        abstract tile : x:'T * reps:ResizeArray<float> -> 'T
        abstract gather : x:'T * indices:U2<Tensor1D, TensorLike1D> * axis:float
         -> 'T
        abstract matMul : a:'T * b:U2<'T, TensorLike> * transposeA:bool * transposeB:bool
         -> 'T
        abstract dot : t1:Tensor * t2:U2<Tensor, TensorLike> -> Tensor
        abstract norm : x:Tensor * ord:U3<float, string, string> * axis:U2<float, ResizeArray<float>> * keepDims:bool
         -> Tensor
        abstract slice : x:'T * ``begin``:U2<float, ResizeArray<float>> * ?size:U2<float, ResizeArray<float>>
         -> 'T
        abstract split : x:'T * numOrSizeSplits:U2<ResizeArray<float>, float> * ?axis:float
         -> ResizeArray<'T>
        abstract reverse : x:'T * ?axis:U2<float, ResizeArray<float>> -> 'T
        abstract concat : tensors:Array<U2<'T, TensorLike>> * axis:float -> 'T
        abstract stack : tensors:Array<U2<'T, TensorLike>> * axis:float
         -> Tensor
        abstract unstack : value:'T * axis:float -> ResizeArray<Tensor>
        abstract pad : x:'T * paddings:Array<float * float> * constantValue:float
         -> 'T
        abstract batchNormalization : x:Tensor<'R> * mean:U3<Tensor<'R>, Tensor1D, TensorLike> * variance:U3<Tensor<'R>, Tensor1D, TensorLike> * varianceEpsilon:float * ?scale:U3<Tensor<'R>, Tensor1D, TensorLike> * ?offset:U3<Tensor<'R>, Tensor1D, TensorLike>
         -> Tensor<'R>
        abstract all : x:Tensor * axis:U2<float, ResizeArray<float>> * keepDims:bool
         -> 'T
        abstract any : x:Tensor * axis:U2<float, ResizeArray<float>> * keepDims:bool
         -> 'T
        abstract logSumExp : x:Tensor * axis:U2<float, ResizeArray<float>> * keepDims:bool
         -> 'T
        abstract sum : x:Tensor * axis:U2<float, ResizeArray<float>> * keepDims:bool
         -> 'T
        abstract prod : x:Tensor * axis:U2<float, ResizeArray<float>> * keepDims:bool
         -> 'T
        abstract mean : x:Tensor * axis:U2<float, ResizeArray<float>> * keepDims:bool
         -> 'T
        abstract min : x:Tensor * axis:U2<float, ResizeArray<float>> * keepDims:bool
         -> 'T
        abstract max : x:Tensor * axis:U2<float, ResizeArray<float>> * keepDims:bool
         -> 'T
        abstract argMin : x:Tensor * axis:float -> 'T
        abstract argMax : x:Tensor * axis:float -> 'T
        abstract add : a:Tensor * b:U2<Tensor, TensorLike> -> 'T
        abstract addStrict : a:'T * b:U2<'T, TensorLike> -> 'T
        abstract atan2 : a:Tensor * b:U2<Tensor, TensorLike> -> 'T
        abstract sub : a:Tensor * b:U2<Tensor, TensorLike> -> 'T
        abstract subStrict : a:'T * b:U2<'T, TensorLike> -> 'T
        abstract pow : ``base``:'T * exp:U2<Tensor, TensorLike> -> 'T
        abstract powStrict : ``base``:'T * exp:U2<Tensor, TensorLike> -> 'T
        abstract mul : a:Tensor * b:U2<Tensor, TensorLike> -> 'T
        abstract mulStrict : a:'T * b:U2<'T, TensorLike> -> 'T
        abstract div : a:Tensor * b:U2<Tensor, TensorLike> -> 'T
        abstract floorDiv : a:Tensor * b:U2<Tensor, TensorLike> -> 'T
        abstract divStrict : a:'T * b:U2<'T, TensorLike> -> 'T
        abstract ``mod`` : a:Tensor * b:U2<Tensor, TensorLike> -> 'T
        abstract modStrict : a:'T * b:U2<'T, TensorLike> -> 'T
        abstract minimum : a:Tensor * b:U2<Tensor, TensorLike> -> 'T
        abstract minimumStrict : a:'T * b:U2<'T, TensorLike> -> 'T
        abstract maximum : a:Tensor * b:U2<Tensor, TensorLike> -> 'T
        abstract maximumStrict : a:'T * b:U2<'T, TensorLike> -> 'T
        abstract squaredDifference : a:Tensor * b:U2<Tensor, TensorLike> -> 'T
        abstract squaredDifferenceStrict : a:'T * b:U2<'T, TensorLike> -> 'T
        abstract transpose : x:'T * ?perm:ResizeArray<float> -> 'T
        abstract logicalNot : x:'T -> 'T
        abstract logicalAnd : a:Tensor * b:U2<Tensor, TensorLike> -> 'T
        abstract logicalOr : a:Tensor * b:U2<Tensor, TensorLike> -> 'T
        abstract logicalXor : a:Tensor * b:U2<Tensor, TensorLike> -> 'T
        abstract where : condition:U2<Tensor, TensorLike> * a:'T * b:U2<'T, TensorLike>
         -> 'T
        abstract notEqual : a:Tensor * b:U2<Tensor, TensorLike> -> 'T
        abstract notEqualStrict : a:'T * b:U2<'T, TensorLike> -> 'T
        abstract less : a:Tensor * b:U2<Tensor, TensorLike> -> 'T
        abstract lessStrict : a:'T * b:U2<'T, TensorLike> -> 'T
        abstract equal : a:Tensor * b:U2<Tensor, TensorLike> -> 'T
        abstract equalStrict : a:'T * b:U2<'T, TensorLike> -> 'T
        abstract lessEqual : a:Tensor * b:U2<Tensor, TensorLike> -> 'T
        abstract lessEqualStrict : a:'T * b:U2<'T, TensorLike> -> 'T
        abstract greater : a:Tensor * b:U2<Tensor, TensorLike> -> 'T
        abstract greaterStrict : a:'T * b:U2<'T, TensorLike> -> 'T
        abstract greaterEqual : a:Tensor * b:U2<Tensor, TensorLike> -> 'T
        abstract greaterEqualStrict : a:'T * b:U2<'T, TensorLike> -> 'T
        abstract neg : x:'T -> 'T
        abstract ceil : x:'T -> 'T
        abstract floor : x:'T -> 'T
        abstract sign : x:'T -> 'T
        abstract round : x:'T -> 'T
        abstract exp : x:'T -> 'T
        abstract expm1 : x:'T -> 'T
        abstract log : x:'T -> 'T
        abstract log1p : x:'T -> 'T
        abstract sqrt : x:'T -> 'T
        abstract rsqrt : x:'T -> 'T
        abstract square : x:'T -> 'T
        abstract reciprocal : x:'T -> 'T
        abstract abs : x:'T -> 'T
        abstract clipByValue : x:'T * clipValueMin:float * clipValueMax:float
         -> 'T
        abstract sigmoid : x:'T -> 'T
        abstract logSigmoid : x:'T -> 'T
        abstract softplus : x:'T -> 'T
        abstract zerosLike : x:'T -> 'T
        abstract onesLike : x:'T -> 'T
        abstract sin : x:'T -> 'T
        abstract cos : x:'T -> 'T
        abstract tan : x:'T -> 'T
        abstract asin : x:'T -> 'T
        abstract acos : x:'T -> 'T
        abstract atan : x:'T -> 'T
        abstract sinh : x:'T -> 'T
        abstract cosh : x:'T -> 'T
        abstract tanh : x:'T -> 'T
        abstract asinh : x:'T -> 'T
        abstract acosh : x:'T -> 'T
        abstract atanh : x:'T -> 'T
        abstract erf : x:'T -> 'T
        abstract step : x:'T * alpha:float -> 'T
        abstract relu : x:'T -> 'T
        abstract elu : x:'T -> 'T
        abstract selu : x:'T -> 'T
        abstract leakyRelu : x:'T * alpha:float -> 'T
        abstract prelu : x:'T * alpha:U2<'T, TensorLike> -> 'T
        abstract softmax : logits:'T * dim:float -> 'T
        abstract logSoftmax : logits:'T * axis:float -> 'T
        abstract image : obj with get, set
        abstract conv1d : x:'T * filter:U2<Tensor3D, TensorLike3D> * stride:float * pad:U3<string, string, float> * dataFormat:U2<string, string> * dilation:float * ?dimRoundingMode:U3<string, string, string>
         -> 'T
        abstract conv2d : x:'T * filter:U2<Tensor4D, TensorLike4D> * strides:U2<float * float, float> * pad:U3<string, string, float> * dataFormat:U2<string, string> * dilations:U2<float * float, float> * ?dimRoundingMode:U3<string, string, string>
         -> 'T
        abstract conv2dTranspose : x:'T * filter:U2<Tensor4D, TensorLike4D> * outputShape:U2<float * float * float * float, float * float * float> * strides:U2<float * float, float> * pad:U3<string, string, float> * ?dimRoundingMode:U3<string, string, string>
         -> 'T
        abstract depthwiseConv2d : x:'T * filter:U2<Tensor4D, TensorLike4D> * strides:U2<float * float, float> * pad:U3<string, string, float> * dataFormat:U2<string, string> * dilations:U2<float * float, float> * ?dimRoundingMode:U3<string, string, string>
         -> 'T
        abstract separableConv2d : x:U2<'T, TensorLike> * depthwiseFilter:U2<Tensor4D, TensorLike4D> * pointwiseFilter:U2<Tensor4D, TensorLike> * strides:U2<float * float, float> * pad:U2<string, string> * dilation:U2<float * float, float> * dataFormat:U2<string, string>
         -> 'T
        abstract maxPool : x:'T * filterSize:U2<float * float, float> * strides:U2<float * float, float> * pad:U3<string, string, float> * ?dimRoundingMode:U3<string, string, string>
         -> 'T
        abstract avgPool : x:'T * filterSize:U2<float * float, float> * strides:U2<float * float, float> * pad:U3<string, string, float> * ?dimRoundingMode:U3<string, string, string>
         -> 'T
        abstract pool : input:'T * windowShape:U2<float * float, float> * poolingType:U2<string, string> * padding:U3<string, string, float> * ?diationRate:U2<float * float, float> * ?strides:U2<float * float, float>
         -> 'T
        abstract localResponseNormalization : x:'T * depthRadius:float * bias:float * alpha:float * beta:float
         -> 'T
        abstract unsortedSegmentSum : x:'T * segmentIds:U2<Tensor1D, TensorLike1D> * numSegments:float
         -> 'T
        abstract batchToSpaceND : x:'T * blockShape:ResizeArray<float> * crops:ResizeArray<ResizeArray<float>>
         -> 'T
        abstract spaceToBatchND : x:'T * blockShape:ResizeArray<float> * paddings:ResizeArray<ResizeArray<float>>
         -> 'T
        abstract topk : x:'T * k:float * sorted:bool -> obj
        abstract stridedSlice : x:'T * ``begin``:ResizeArray<float> * ``end``:ResizeArray<float> * strides:ResizeArray<float> * beginMask:float * endMask:float
         -> 'T
        abstract depthToSpace : x:Tensor4D * blockSize:float * dataFormat:string
         -> Tensor4D
        abstract spectral : obj with get, set

    type DataId = obj

    type Tensor = Tensor<Rank>

    [<AllowNullLiteral>]
    type Tensor<'R> =
        abstract id : float
        abstract dataId : DataId with get, set
        abstract shape : float []
        abstract size : float
        abstract dtype : DataType
        abstract rankType : 'R
        abstract strides : ResizeArray<float>
        abstract flatten : unit -> Tensor1D
        abstract asScalar : unit -> Scalar
        abstract as1D : unit -> Tensor1D
        abstract as2D : rows:float * columns:float -> Tensor2D
        abstract as3D : rows:float * columns:float * depth:float -> Tensor3D
        abstract as4D : rows:float * columns:float * depth:float * depth2:float
         -> Tensor4D
        abstract as5D : rows:float * columns:float * depth:float * depth2:float * depth3:float
         -> Tensor5D
        abstract asType : this:'T * dtype:DataType -> 'T
        abstract rank : float
        abstract get : [<ParamArray>] locs:ResizeArray<float> -> float
        abstract buffer : unit -> TensorBuffer<'R, 'D>
        abstract data : unit -> Promise<DataTypeMap>
        abstract dataSync : unit -> DataTypeMap
        abstract dispose : unit -> unit
        abstract isDisposedInternal : obj with get, set
        abstract isDisposed : bool
        abstract throwIfDisposed : obj with get, set
        abstract toFloat : this:'T -> 'T
        abstract toInt : unit -> Tensor<'R>
        abstract toBool : unit -> Tensor<'R>
        abstract print : verbose:bool -> unit
        abstract reshape : newShape:ShapeMap -> Tensor<'R2>
        abstract reshapeAs : x:'T -> 'T
        abstract expandDims : axis:float -> Tensor<'R2>
        abstract cumsum : ?axis:float * ?exclusive:bool * ?reverse:bool -> 'T
        abstract squeeze : axis:ResizeArray<float> -> 'T
        abstract clone : this:'T -> 'T
        abstract toString : verbose:bool -> string
        abstract tile : this:'T * reps:ResizeArray<float> -> 'T
        abstract gather : this:'T * indices:U2<Tensor1D, TensorLike1D> * ?axis:float
         -> 'T
        abstract matMul : this:'T * b:U2<'T, TensorLike> * ?transposeA:bool * ?transposeB:bool
         -> 'T
        abstract dot : b:U2<Tensor, TensorLike> -> Tensor
        abstract norm : ?ord:U3<float, string, string> * ?axis:U2<float, ResizeArray<float>> * ?keepDims:bool
         -> Tensor
        abstract slice : this:'T * ``begin``:U2<float, ResizeArray<float>> * ?size:U2<float, ResizeArray<float>>
         -> 'T
        abstract reverse : this:'T * ?axis:U2<float, ResizeArray<float>> -> 'T
        abstract concat : this:'T * x:U2<'T, Array<U2<'T, TensorLike>>> * ?axis:float
         -> 'T
        abstract split : this:'T * numOrSizeSplits:U2<ResizeArray<float>, float> * ?axis:float
         -> ResizeArray<'T>
        abstract stack : x:Tensor * ?axis:float -> Tensor
        abstract unstack : x:Tensor * ?axis:float -> ResizeArray<Tensor>
        abstract pad : this:'T * paddings:Array<float * float> * ?constantValue:float
         -> 'T
        abstract batchNormalization : mean:U3<Tensor<'R>, Tensor1D, TensorLike> * variance:U3<Tensor<'R>, Tensor1D, TensorLike> * ?varianceEpsilon:float * ?scale:U3<Tensor<'R>, Tensor1D, TensorLike> * ?offset:U3<Tensor<'R>, Tensor1D, TensorLike>
         -> Tensor<'R>
        abstract all : ?axis:U2<float, ResizeArray<float>> * ?keepDims:bool
         -> 'T
        abstract any : ?axis:U2<float, ResizeArray<float>> * ?keepDims:bool
         -> 'T
        abstract logSumExp : ?axis:U2<float, ResizeArray<float>> * ?keepDims:bool
         -> 'T
        abstract sum : ?axis:U2<float, ResizeArray<float>> * ?keepDims:bool
         -> 'T
        abstract prod : ?axis:U2<float, ResizeArray<float>> * ?keepDims:bool
         -> 'T
        abstract mean : ?axis:U2<float, ResizeArray<float>> * ?keepDims:bool
         -> 'T
        abstract min : ?axis:U2<float, ResizeArray<float>> * ?keepDims:bool
         -> 'T
        abstract max : ?axis:U2<float, ResizeArray<float>> * ?keepDims:bool
         -> 'T
        abstract argMin : axis:float -> 'T
        abstract argMax : axis:float -> 'T
        abstract cast : dtype:DataType -> 'T
        abstract add : x:U2<Tensor, TensorLike> -> 'T
        abstract addStrict : this:'T * x:U2<'T, TensorLike> -> 'T
        abstract atan2 : this:'T * x:U2<'T, TensorLike> -> 'T
        abstract sub : x:U2<Tensor, TensorLike> -> 'T
        abstract subStrict : this:'T * x:U2<'T, TensorLike> -> 'T
        abstract pow : this:'T * exp:U2<Tensor, TensorLike> -> 'T
        abstract powStrict : exp:U2<Tensor, TensorLike> -> Tensor<'R>
        abstract mul : x:U2<Tensor, TensorLike> -> 'T
        abstract mulStrict : this:'T * x:U2<'T, TensorLike> -> 'T
        abstract div : x:U2<Tensor, TensorLike> -> 'T
        abstract floorDiv : x:U2<Tensor, TensorLike> -> 'T
        abstract divStrict : this:'T * x:U2<'T, TensorLike> -> 'T
        abstract minimum : x:U2<Tensor, TensorLike> -> 'T
        abstract minimumStrict : this:'T * x:U2<'T, TensorLike> -> 'T
        abstract maximum : x:U2<Tensor, TensorLike> -> 'T
        abstract maximumStrict : this:'T * x:U2<'T, TensorLike> -> 'T
        abstract ``mod`` : x:U2<Tensor, TensorLike> -> 'T
        abstract modStrict : this:'T * x:U2<'T, TensorLike> -> 'T
        abstract squaredDifference : x:U2<Tensor, TensorLike> -> 'T
        abstract squaredDifferenceStrict : this:'T * x:U2<'T, TensorLike> -> 'T
        abstract transpose : this:'T * ?perm:ResizeArray<float> -> 'T
        abstract notEqual : x:U2<Tensor, TensorLike> -> 'T
        abstract notEqualStrict : this:'T * x:U2<'T, TensorLike> -> 'T
        abstract less : x:U2<Tensor, TensorLike> -> 'T
        abstract lessStrict : this:'T * x:U2<'T, TensorLike> -> 'T
        abstract equal : x:U2<Tensor, TensorLike> -> 'T
        abstract equalStrict : this:'T * x:U2<'T, TensorLike> -> 'T
        abstract lessEqual : x:U2<Tensor, TensorLike> -> 'T
        abstract lessEqualStrict : this:'T * x:U2<'T, TensorLike> -> 'T
        abstract greater : x:U2<Tensor, TensorLike> -> 'T
        abstract greaterStrict : this:'T * x:U2<'T, TensorLike> -> 'T
        abstract greaterEqual : x:U2<Tensor, TensorLike> -> 'T
        abstract greaterEqualStrict : this:'T * x:U2<'T, TensorLike> -> 'T
        abstract logicalAnd : x:U2<Tensor, TensorLike> -> Tensor
        abstract logicalOr : x:U2<Tensor, TensorLike> -> Tensor
        abstract logicalNot : this:'T -> 'T
        abstract logicalXor : x:U2<Tensor, TensorLike> -> Tensor
        abstract where : condition:U2<Tensor, TensorLike> * x:U2<Tensor, TensorLike>
         -> Tensor
        abstract neg : this:'T -> 'T
        abstract ceil : this:'T -> 'T
        abstract floor : this:'T -> 'T
        abstract sign : this:'T -> 'T
        abstract exp : this:'T -> 'T
        abstract expm1 : this:'T -> 'T
        abstract log : this:'T -> 'T
        abstract log1p : this:'T -> 'T
        abstract sqrt : this:'T -> 'T
        abstract rsqrt : this:'T -> 'T
        abstract square : this:'T -> 'T
        abstract reciprocal : this:'T -> 'T
        abstract abs : this:'T -> 'T
        abstract clipByValue : min:float * max:float -> Tensor<'R>
        abstract relu : this:'T -> 'T
        abstract elu : this:'T -> 'T
        abstract selu : this:'T -> 'T
        abstract leakyRelu : alpha:float -> Tensor<'R>
        abstract prelu : alpha:U2<Tensor<'R>, TensorLike> -> Tensor<'R>
        abstract sigmoid : this:'T -> 'T
        abstract logSigmoid : this:'T -> 'T
        abstract softplus : this:'T -> 'T
        abstract zerosLike : this:'T -> 'T
        abstract onesLike : this:'T -> 'T
        abstract sin : this:'T -> 'T
        abstract cos : this:'T -> 'T
        abstract tan : this:'T -> 'T
        abstract asin : this:'T -> 'T
        abstract acos : this:'T -> 'T
        abstract atan : this:'T -> 'T
        abstract sinh : this:'T -> 'T
        abstract cosh : this:'T -> 'T
        abstract tanh : this:'T -> 'T
        abstract asinh : this:'T -> 'T
        abstract acosh : this:'T -> 'T
        abstract atanh : this:'T -> 'T
        abstract erf : this:'T -> 'T
        abstract round : this:'T -> 'T
        abstract step : this:'T * ?alpha:float -> 'T
        abstract softmax : this:'T * ?dim:float -> 'T
        abstract logSoftmax : this:'T * ?axis:float -> 'T
        abstract resizeBilinear : this:'T * newShape2D:float * float * ?alignCorners:bool
         -> 'T
        abstract resizeNearestNeighbor : this:'T * newShape2D:float * float * ?alignCorners:bool
         -> 'T
        abstract conv1d : this:'T * filter:U2<Tensor3D, TensorLike3D> * stride:float * pad:U3<string, string, float> * ?dataFormat:U2<string, string> * ?dilation:float * ?dimRoundingMode:U3<string, string, string>
         -> 'T
        abstract conv2d : this:'T * filter:U2<Tensor4D, TensorLike4D> * strides:U2<float * float, float> * pad:U3<string, string, float> * ?dataFormat:U2<string, string> * ?dilations:U2<float * float, float> * ?dimRoundingMode:U3<string, string, string>
         -> 'T
        abstract conv2dTranspose : this:'T * filter:U2<Tensor4D, TensorLike4D> * outputShape:U2<float * float * float * float, float * float * float> * strides:U2<float * float, float> * pad:U3<string, string, float> * ?dimRoundingMode:U3<string, string, string>
         -> 'T
        abstract depthwiseConv2D : this:'T * filter:U2<Tensor4D, TensorLike4D> * strides:U2<float * float, float> * pad:U3<string, string, float> * ?dataFormat:U2<string, string> * ?dilations:U2<float * float, float> * ?dimRoundingMode:U3<string, string, string>
         -> 'T
        abstract separableConv2d : this:U2<'T, TensorLike> * depthwiseFilter:U2<Tensor4D, TensorLike4D> * pointwiseFilter:U2<Tensor4D, TensorLike> * strides:U2<float * float, float> * pad:U2<string, string> * ?dilation:U2<float * float, float> * ?dataFormat:U2<string, string>
         -> 'T
        abstract avgPool : this:'T * filterSize:U2<float * float, float> * strides:U2<float * float, float> * pad:U3<string, string, float> * ?dimRoundingMode:U3<string, string, string>
         -> 'T
        abstract maxPool : this:'T * filterSize:U2<float * float, float> * strides:U2<float * float, float> * pad:U3<string, string, float> * ?dimRoundingMode:U3<string, string, string>
         -> 'T
        abstract localResponseNormalization : this:'T * ?radius:float * ?bias:float * ?alpha:float * ?beta:float
         -> 'T
        abstract pool : this:'T * windowShape:U2<float * float, float> * poolingType:U2<string, string> * padding:U3<string, string, float> * ?dilationRate:U2<float * float, float> * ?strides:U2<float * float, float>
         -> 'T
        abstract variable : ?trainable:bool * ?name:string * ?dtype:DataType
         -> Variable<'R>
        abstract unsortedSegmentSum : this:'T * segmentIds:U2<Tensor1D, TensorLike1D> * numSegments:float
         -> 'T
        abstract batchToSpaceND : this:'T * blockShape:ResizeArray<float> * crops:ResizeArray<ResizeArray<float>>
         -> 'T
        abstract spaceToBatchND : this:'T * blockShape:ResizeArray<float> * paddings:ResizeArray<ResizeArray<float>>
         -> 'T
        abstract topk : this:'T * ?k:float * ?sorted:bool -> obj
        abstract stridedSlice : this:'T * ``begin``:ResizeArray<float> * ``end``:ResizeArray<float> * strides:ResizeArray<float> * ?beginMask:float * ?endMask:float
         -> 'T
        abstract depthToSpace : this:Tensor4D * blockSize:float * dataFormat:U2<string, string>
         -> Tensor4D
        abstract fft : this:Tensor -> Tensor
        abstract ifft : this:Tensor -> Tensor

    [<AllowNullLiteral>]
    type TensorStatic =

        [<Emit"new $0($1...)">]
        abstract Create : shape:ShapeMap * dtype:DataType * ?values:DataValues * ?dataId:DataId
         -> Tensor<'R>

        abstract make : shape:ShapeMap * data:TensorData<'D> * ?dtype:'D -> 'T

    type NumericTensor = NumericTensor<obj>

    [<AllowNullLiteral>]
    type NumericTensor<'R> =
        inherit Tensor<'R>
        abstract dtype : NumericDataType with get, set
        abstract data : unit -> Promise<TypedArray>
        abstract dataSync : unit -> TypedArray

    type StringTensor = StringTensor<obj>

    [<AllowNullLiteral>]
    type StringTensor<'R> =
        inherit Tensor<'R>
        abstract dtype : string with get, set
        abstract dataSync : unit -> ResizeArray<string>
        abstract data : unit -> Promise<ResizeArray<string>>

    // type Scalar = Tensor<Rank.R0>

    // type Tensor1D = Tensor<Rank.R1>

    // type Tensor2D = Tensor<Rank.R2>

    // type Tensor3D = Tensor<Rank.R3>

    // type Tensor4D = Tensor<Rank.R4>

    // type Tensor5D = Tensor<Rank.R5>

    // type Tensor6D = Tensor<Rank.R6>


    type Scalar = Tensor<Rank>

    type Tensor1D = Tensor<Rank>

    type Tensor2D = Tensor<Rank>

    type Tensor3D = Tensor<Rank>

    type Tensor4D = Tensor<Rank>

    type Tensor5D = Tensor<Rank>

    type Tensor6D = Tensor<Rank>

    type Variable = Variable<obj>

    [<AllowNullLiteral>]
    type Variable<'R> =
        inherit Tensor<'R>
        abstract trainable : bool with get, set
        abstract name : string with get, set
        abstract assign : newValue:Tensor<'R> -> unit

    [<AllowNullLiteral>]
    type VariableStatic =

        [<Emit"new $0($1...)">]
        abstract Create : unit -> Variable<'R>

        abstract variable : initialValue:Tensor<'R> * ?trainable:bool * ?name:string * ?dtype:DataType
         -> Variable<'R>
