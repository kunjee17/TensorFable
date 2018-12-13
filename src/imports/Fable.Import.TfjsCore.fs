// // ts2fable 0.6.1
// module rec Fable.Import.TfjsCore
// open System
// open Fable.Core
// open Fable.Import.JS

// let [<Import("*","@tensorflow/tfjs-core/dist/environment_util")>] URL_PROPERTIES: ResizeArray<URLProperty> = jsNative

// type [<AllowNullLiteral>] IExports =
//     abstract isWebGLVersionEnabled: webGLVersion: obj -> bool
//     abstract getWebGLMaxTextureSize: webGLVersion: float -> float
//     abstract getWebGLDisjointQueryTimerVersion: webGLVersion: float -> float
//     abstract isRenderToFloatTextureEnabled: webGLVersion: float -> bool
//     abstract isDownloadFloatTextureEnabled: webGLVersion: float -> bool
//     abstract isWebGLFenceEnabled: webGLVersion: float -> bool
//     abstract isChrome: unit -> bool
//     abstract getFeaturesFromURL: unit -> Features
//     abstract getQueryParams: queryString: string -> obj

// type [<AllowNullLiteral>] Features =
//     abstract DEBUG: bool option with get, set
//     abstract IS_BROWSER: bool option with get, set
//     abstract IS_NODE: bool option with get, set
//     abstract WEBGL_LAZILY_UNPACK: bool option with get, set
//     abstract WEBGL_CPU_FORWARD: bool option with get, set
//     abstract WEBGL_PACK: bool option with get, set
//     abstract WEBGL_PACK_BATCHNORMALIZATION: bool option with get, set
//     abstract WEBGL_PACK_CLIP: bool option with get, set
//     abstract WEBGL_PACK_DEPTHWISECONV: bool option with get, set
//     abstract WEBGL_CONV_IM2COL: bool option with get, set
//     abstract WEBGL_PAGING_ENABLED: bool option with get, set
//     abstract WEBGL_MAX_TEXTURE_SIZE: float option with get, set
//     abstract WEBGL_DISJOINT_QUERY_TIMER_EXTENSION_VERSION: float option with get, set
//     abstract WEBGL_DISJOINT_QUERY_TIMER_EXTENSION_RELIABLE: bool option with get, set
//     abstract WEBGL_VERSION: float option with get, set
//     abstract HAS_WEBGL: bool option with get, set
//     abstract WEBGL_RENDER_FLOAT32_ENABLED: bool option with get, set
//     abstract WEBGL_DOWNLOAD_FLOAT_ENABLED: bool option with get, set
//     abstract WEBGL_FENCE_API_ENABLED: bool option with get, set
//     abstract WEBGL_SIZE_UPLOAD_UNIFORM: float option with get, set
//     abstract BACKEND: string option with get, set
//     abstract TEST_EPSILON: float option with get, set
//     abstract IS_CHROME: bool option with get, set
//     abstract IS_TEST: bool option with get, set
//     abstract EPSILON: float option with get, set
//     abstract PROD: bool option with get, set
//     abstract TENSORLIKE_CHECK_SHAPE_CONSISTENCY: bool option with get, set

// type [<RequireQualifiedAccess>] Type =
//     | NUMBER = 0
//     | BOOLEAN = 1
//     | STRING = 2

// type [<AllowNullLiteral>] URLProperty =
//     abstract name: obj with get, set
//     abstract ``type``: Type with get, set
// type Engine = __engine.Engine
// type MemoryInfo = __engine.MemoryInfo
// type ProfileInfo = __engine.ProfileInfo
// type ScopeFn = __engine.ScopeFn
// type TimingInfo = __engine.TimingInfo
// // type Features = __environment_util.Features
// type KernelBackend = __kernels_backend.KernelBackend
// type Tensor = __tensor.Tensor
// type TensorTracker = __tensor.TensorTracker
// type TensorContainer = __tensor_types.TensorContainer
// let [<Import("*","@tensorflow/tfjs-core/dist/environment")>] EPSILON_FLOAT16: obj = jsNative
// let [<Import("*","@tensorflow/tfjs-core/dist/environment")>] EPSILON_FLOAT32: obj = jsNative
// let [<Import("*","@tensorflow/tfjs-core/dist/environment")>] ENV: Environment = jsNative

// type [<AllowNullLiteral>] IExports =
//     abstract Environment: EnvironmentStatic

// type [<AllowNullLiteral>] Environment =
//     abstract features: obj with get, set
//     abstract globalEngine: obj with get, set
//     abstract registry: obj with get, set
//     abstract backendName: string with get, set
//     abstract get: feature: 'K -> Features
//     abstract getFeatures: unit -> Features
//     abstract set: feature: 'K * value: Features -> unit
//     abstract getBestBackendName: obj with get, set
//     abstract evaluateFeature: obj with get, set
//     abstract setFeatures: features: Features -> unit
//     abstract reset: unit -> unit
//     abstract backend: KernelBackend
//     abstract findBackend: name: string -> KernelBackend
//     abstract registerBackend: name: string * factory: (unit -> KernelBackend) * ?priority: float * ?setTensorTrackerFn: ((unit -> TensorTracker) -> unit) -> bool
//     abstract removeBackend: name: string -> unit
//     abstract engine: Engine
//     abstract initEngine: obj with get, set

// type [<AllowNullLiteral>] EnvironmentStatic =
//     [<Emit "new $0($1...)">] abstract Create: ?features: Features -> Environment
//     abstract setBackend: backendName: string * ?safeMode: bool -> unit
//     abstract getBackend: unit -> string
//     abstract disposeVariables: unit -> unit
//     abstract memory: unit -> MemoryInfo
//     abstract profile: f: (unit -> TensorContainer) -> Promise<ProfileInfo>
//     abstract tidy: nameOrFn: U2<string, ScopeFn<'T>> * ?fn: ScopeFn<'T> -> 'T
//     abstract dispose: container: TensorContainer -> unit
//     abstract keep: result: 'T -> 'T
//     abstract time: f: (unit -> unit) -> Promise<TimingInfo>
