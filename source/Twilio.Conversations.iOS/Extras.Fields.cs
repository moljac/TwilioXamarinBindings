#define __EFFICIENT_MCPP__
using System;
using System.Runtime.InteropServices;
using CoreGraphics;
using ObjCRuntime;

using Foundation;
using CoreMedia;

namespace Twilio.Conversations
{
	public partial class VideoConstraintsFields : NSObject, IDisposable
	{
		//------------------------------------------------------------------------------------
		#region 	VideoSize352x288
		#if ! __EFFICIENT_MCPP__
		static CMVideoDimensions video_constraints_size_352x288;
		#else
		static CMVideoDimensions? video_constraints_size_352x288;	
		#endif
		public static CMVideoDimensions VideoSize352x288 
		{
			get 
			{
				#if __EFFICIENT_MCPP__
			    if  (video_constraints_size_352x288 != null)
				{
			      return video_constraints_size_352x288.Value;
				}
				#endif

				IntPtr RTLD_MAIN_ONLY = Dlfcn.dlopen (null, 0);
				IntPtr ptr = Dlfcn.dlsym (RTLD_MAIN_ONLY, "TWCVideoConstraintsSize352x288");
				video_constraints_size_352x288 = (CMVideoDimensions)Marshal.PtrToStructure (ptr, typeof(CMVideoDimensions));
				Dlfcn.dlclose (RTLD_MAIN_ONLY);


				#if ! __EFFICIENT_MCPP__
				return video_constraints_size_352x288;
				#else
			    return video_constraints_size_352x288.Value;
				#endif
			}
		}
		#endregion	VideoSize352x288
		//------------------------------------------------------------------------------------


		//------------------------------------------------------------------------------------
		#region 	VideoSize480x360
		#if ! __EFFICIENT_MCPP__
		static CMVideoDimensions video_constraints_size_480x360;
		#else
		static CMVideoDimensions? video_constraints_size_480x360;	
		#endif
		public static CMVideoDimensions VideoSize480x360 
		{
			get 
			{
				#if __EFFICIENT_MCPP__
			    if  (video_constraints_size_480x360 != null)
				{
			      return video_constraints_size_480x360.Value;
				}
				#endif

				IntPtr RTLD_MAIN_ONLY = Dlfcn.dlopen (null, 0);
				IntPtr ptr = Dlfcn.dlsym (RTLD_MAIN_ONLY, "TWCVideoConstraintsSize480x360");
				video_constraints_size_480x360 = (CMVideoDimensions)Marshal.PtrToStructure (ptr, typeof(CMVideoDimensions));
				Dlfcn.dlclose (RTLD_MAIN_ONLY);


				#if ! __EFFICIENT_MCPP__
				return video_constraints_size_480x360;
				#else
			    return video_constraints_size_480x360.Value;
				#endif
			}
		}
		#endregion	VideoSize480x360
		//------------------------------------------------------------------------------------


		//------------------------------------------------------------------------------------
		#region 	VideoSize640x480
		#if ! __EFFICIENT_MCPP__
		static CMVideoDimensions video_constraints_size_640x480;
		#else
		static CMVideoDimensions? video_constraints_size_640x480;	
		#endif
		public static CMVideoDimensions VideoSize640x480 
		{
			get 
			{
				#if __EFFICIENT_MCPP__
			    if  (video_constraints_size_640x480 != null)
				{
			      return video_constraints_size_480x360.Value;
				}
				#endif

				IntPtr RTLD_MAIN_ONLY = Dlfcn.dlopen (null, 0);
				IntPtr ptr = Dlfcn.dlsym (RTLD_MAIN_ONLY, "TWCVideoConstraintsSize640x480");
				video_constraints_size_640x480 = (CMVideoDimensions)Marshal.PtrToStructure (ptr, typeof(CMVideoDimensions));
				Dlfcn.dlclose (RTLD_MAIN_ONLY);


				#if ! __EFFICIENT_MCPP__
				return video_constraints_size_640x480;
				#else
			    return video_constraints_size_640x480.Value;
				#endif
			}
		}
		#endregion	VideoSize640x480
		//------------------------------------------------------------------------------------


		//------------------------------------------------------------------------------------
		#region 	VideoSize960x540
		#if ! __EFFICIENT_MCPP__
		static CMVideoDimensions video_constraints_size_960x540;
		#else
		static CMVideoDimensions? video_constraints_size_960x540;	
		#endif
		public static CMVideoDimensions VideoSize960x540 
		{
			get 
			{
				#if __EFFICIENT_MCPP__
			    if  (video_constraints_size_960x540 != null)
				{
			      return video_constraints_size_960x540.Value;
				}
				#endif

				IntPtr RTLD_MAIN_ONLY = Dlfcn.dlopen (null, 0);
				IntPtr ptr = Dlfcn.dlsym (RTLD_MAIN_ONLY, "TWCVideoConstraintsSize960x540");
				video_constraints_size_960x540 = (CMVideoDimensions)Marshal.PtrToStructure (ptr, typeof(CMVideoDimensions));
				Dlfcn.dlclose (RTLD_MAIN_ONLY);


				#if ! __EFFICIENT_MCPP__
				return video_constraints_size_960x540;
				#else
			    return video_constraints_size_960x540.Value;
				#endif
			}
		}
		#endregion	VideoSize960x540
		//------------------------------------------------------------------------------------


		//------------------------------------------------------------------------------------
		#region 	VideoSize1280x720
		#if ! __EFFICIENT_MCPP__
		static CMVideoDimensions video_constraints_size_1280x720;
		#else
		static CMVideoDimensions? video_constraints_size_1280x720;	
		#endif
		public static CMVideoDimensions VideoSize1280x720 
		{
			get 
			{
				#if __EFFICIENT_MCPP__
			    if  (video_constraints_size_1280x720 != null)
				{
			      return video_constraints_size_1280x720.Value;
				}
				#endif

				IntPtr RTLD_MAIN_ONLY = Dlfcn.dlopen (null, 0);
				IntPtr ptr = Dlfcn.dlsym (RTLD_MAIN_ONLY, "TWCVideoConstraintsSize1280x720");
				video_constraints_size_1280x720 = (CMVideoDimensions)Marshal.PtrToStructure (ptr, typeof(CMVideoDimensions));
				Dlfcn.dlclose (RTLD_MAIN_ONLY);


				#if ! __EFFICIENT_MCPP__
				return video_constraints_size_1280x720;
				#else
			    return video_constraints_size_1280x720.Value;
				#endif
			}
		}
		#endregion	VideoSize1280x720
		//------------------------------------------------------------------------------------


		//------------------------------------------------------------------------------------
		#region 	VideoSize1280x960
		#if ! __EFFICIENT_MCPP__
		static CMVideoDimensions video_constraints_size_1280x960;
		#else
		static CMVideoDimensions? video_constraints_size_1280x960;	
		#endif
		public static CMVideoDimensions VideoSize1280x960 
		{
			get 
			{
				#if __EFFICIENT_MCPP__
			    if  (video_constraints_size_1280x960 != null)
				{
			      return video_constraints_size_1280x960.Value;
				}
				#endif

				IntPtr RTLD_MAIN_ONLY = Dlfcn.dlopen (null, 0);
				IntPtr ptr = Dlfcn.dlsym (RTLD_MAIN_ONLY, "TWCVideoConstraintsSize1280x960");
				video_constraints_size_1280x960 = (CMVideoDimensions)Marshal.PtrToStructure (ptr, typeof(CMVideoDimensions));
				Dlfcn.dlclose (RTLD_MAIN_ONLY);


				#if ! __EFFICIENT_MCPP__
				return video_constraints_size_1280x960;
				#else
			    return video_constraints_size_1280x960.Value;
				#endif
			}
		}
		#endregion	VideoSize1280x960
		//------------------------------------------------------------------------------------


		//------------------------------------------------------------------------------------
		#region 	FrameRate30
		#if ! __EFFICIENT_MCPP__
		static nuint frame_rate_30;
		#else
		static nuint? frame_rate_30;	
		#endif
		public static nuint FrameRate30 
		{
			get 
			{
				#if __EFFICIENT_MCPP__
			    if  (frame_rate_30 != null)
				{
			      return frame_rate_30.Value;
				}
				#endif

				IntPtr RTLD_MAIN_ONLY = Dlfcn.dlopen (null, 0);
				IntPtr ptr = Dlfcn.dlsym (RTLD_MAIN_ONLY, "TWCVideoConstraintsFrameRate30");
				frame_rate_30 = (nuint)Marshal.PtrToStructure (ptr, typeof(nuint));
				Dlfcn.dlclose (RTLD_MAIN_ONLY);


				#if ! __EFFICIENT_MCPP__
				return frame_rate_30;
				#else
			    return frame_rate_30.Value;
				#endif
			}
		}
		#endregion	FrameRate30
		//------------------------------------------------------------------------------------


		//------------------------------------------------------------------------------------
		#region 	FrameRate24
		#if ! __EFFICIENT_MCPP__
		static nuint frame_rate_24;
		#else
		static nuint? frame_rate_24;	
		#endif
		public static nuint FrameRate24 
		{
			get 
			{
				#if __EFFICIENT_MCPP__
			    if  (frame_rate_24 != null)
				{
			      return frame_rate_24.Value;
				}
				#endif

				IntPtr RTLD_MAIN_ONLY = Dlfcn.dlopen (null, 0);
				IntPtr ptr = Dlfcn.dlsym (RTLD_MAIN_ONLY, "TWCVideoConstraintsFrameRate24");
				frame_rate_24 = (nuint)Marshal.PtrToStructure (ptr, typeof(nuint));
				Dlfcn.dlclose (RTLD_MAIN_ONLY);


				#if ! __EFFICIENT_MCPP__
				return frame_rate_24;
				#else
			    return frame_rate_24.Value;
				#endif
			}
		}
		#endregion	FrameRate24
		//------------------------------------------------------------------------------------


		//------------------------------------------------------------------------------------
		#region 	FrameRate20
		#if ! __EFFICIENT_MCPP__
		static nuint frame_rate_20;
		#else
		static nuint? frame_rate_20;	
		#endif
		public static nuint FrameRate20 
		{
			get 
			{
				#if __EFFICIENT_MCPP__
			    if  (frame_rate_20 != null)
				{
			      return frame_rate_20.Value;
				}
				#endif

				IntPtr RTLD_MAIN_ONLY = Dlfcn.dlopen (null, 0);
				IntPtr ptr = Dlfcn.dlsym (RTLD_MAIN_ONLY, "TWCVideoConstraintsFrameRate20");
				frame_rate_20 = (nuint)Marshal.PtrToStructure (ptr, typeof(nuint));
				Dlfcn.dlclose (RTLD_MAIN_ONLY);


				#if ! __EFFICIENT_MCPP__
				return frame_rate_20;
				#else
			    return frame_rate_20.Value;
				#endif
			}
		}
		#endregion	FrameRate20
		//------------------------------------------------------------------------------------


		//------------------------------------------------------------------------------------
		#region 	FrameRate15
		#if ! __EFFICIENT_MCPP__
		static nuint frame_rate_15;
		#else
		static nuint? frame_rate_15;	
		#endif
		public static nuint FrameRate15 
		{
			get 
			{
				#if __EFFICIENT_MCPP__
			    if  (frame_rate_15 != null)
				{
			      return frame_rate_15.Value;
				}
				#endif

				IntPtr RTLD_MAIN_ONLY = Dlfcn.dlopen (null, 0);
				IntPtr ptr = Dlfcn.dlsym (RTLD_MAIN_ONLY, "TWCVideoConstraintsFrameRate15");
				frame_rate_15 = (nuint)Marshal.PtrToStructure (ptr, typeof(nuint));
				Dlfcn.dlclose (RTLD_MAIN_ONLY);


				#if ! __EFFICIENT_MCPP__
				return frame_rate_15;
				#else
			    return frame_rate_15.Value;
				#endif
			}
		}
		#endregion	FrameRate15
		//------------------------------------------------------------------------------------


		//------------------------------------------------------------------------------------
		#region 	FrameRate10
		#if ! __EFFICIENT_MCPP__
		static nuint frame_rate_10;
		#else
		static nuint? frame_rate_10;	
		#endif
		public static nuint FrameRate10 
		{
			get 
			{
				#if __EFFICIENT_MCPP__
			    if  (frame_rate_10 != null)
				{
			      return frame_rate_10.Value;
				}
				#endif

				IntPtr RTLD_MAIN_ONLY = Dlfcn.dlopen (null, 0);
				IntPtr ptr = Dlfcn.dlsym (RTLD_MAIN_ONLY, "TWCVideoConstraintsFrameRate10");
				frame_rate_10 = (nuint)Marshal.PtrToStructure (ptr, typeof(nuint));
				Dlfcn.dlclose (RTLD_MAIN_ONLY);


				#if ! __EFFICIENT_MCPP__
				return frame_rate_10;
				#else
			    return frame_rate_10.Value;
				#endif
			}
		}
		#endregion	FrameRate10
		//------------------------------------------------------------------------------------


		//------------------------------------------------------------------------------------
		#region 	VideoConstraintsMaximumFPS
		#if ! __EFFICIENT_MCPP__
		static nuint video_constraints_maximum_fps;
		#else
		static nuint? video_constraints_maximum_fps;	
		#endif
		public static nuint VideoConstraintsMaximumFPS 
		{
			get 
			{
				#if __EFFICIENT_MCPP__
			    if  (video_constraints_maximum_fps != null)
				{
			      return video_constraints_maximum_fps.Value;
				}
				#endif

				IntPtr RTLD_MAIN_ONLY = Dlfcn.dlopen (null, 0);
				IntPtr ptr = Dlfcn.dlsym (RTLD_MAIN_ONLY, "TWCVideoConstraintsMaximumFPS");
				video_constraints_maximum_fps = (nuint)Marshal.PtrToStructure (ptr, typeof(nuint));
				Dlfcn.dlclose (RTLD_MAIN_ONLY);


				#if ! __EFFICIENT_MCPP__
				return video_constraints_maximum_fps;
				#else
			    return video_constraints_maximum_fps.Value;
				#endif
			}
		}
		#endregion	VideoConstraintsMaximumFPS
		//------------------------------------------------------------------------------------


		//------------------------------------------------------------------------------------
		#region 	VideoConstraintsMinimumFPS
		#if ! __EFFICIENT_MCPP__
		static nuint video_constraints_minimum_fps;
		#else
		static nuint? video_constraints_minimum_fps;	
		#endif
		public static nuint VideoConstraintsMinimumFPS 
		{
			get 
			{
				#if __EFFICIENT_MCPP__
			    if  (video_constraints_minimum_fps != null)
				{
			      return video_constraints_minimum_fps.Value;
				}
				#endif

				IntPtr RTLD_MAIN_ONLY = Dlfcn.dlopen (null, 0);
				IntPtr ptr = Dlfcn.dlsym (RTLD_MAIN_ONLY, "TWCVideoConstraintsMinimumFPS");
				video_constraints_minimum_fps = (nuint)Marshal.PtrToStructure (ptr, typeof(nuint));
				Dlfcn.dlclose (RTLD_MAIN_ONLY);


				#if ! __EFFICIENT_MCPP__
				return video_constraints_minimum_fps;
				#else
			    return video_constraints_minimum_fps.Value;
				#endif
			}
		}
		#endregion	VideoConstraintsMinimumFPS
		//------------------------------------------------------------------------------------


		//------------------------------------------------------------------------------------
		#region 	VideoSizeConstraintsNone
		#if ! __EFFICIENT_MCPP__
		static CMVideoDimensions video_size_constraints_none;
		#else
		static CMVideoDimensions? video_size_constraints_none;	
		#endif
		public static CMVideoDimensions VideoSizeConstraintsNone 
		{
			get 
			{
				#if __EFFICIENT_MCPP__
			    if  (video_size_constraints_none != null)
				{
			      return video_size_constraints_none.Value;
				}
				#endif

				IntPtr RTLD_MAIN_ONLY = Dlfcn.dlopen (null, 0);
				IntPtr ptr = Dlfcn.dlsym (RTLD_MAIN_ONLY, "TWCVideoSizeConstraintsNone");
				video_size_constraints_none = (CMVideoDimensions)Marshal.PtrToStructure (ptr, typeof(CMVideoDimensions));
				Dlfcn.dlclose (RTLD_MAIN_ONLY);


				#if ! __EFFICIENT_MCPP__
				return video_size_constraints_none;
				#else
			    return video_size_constraints_none.Value;
				#endif
			}
		}
		#endregion	VideoSizeConstraintsNone
		//------------------------------------------------------------------------------------


		//------------------------------------------------------------------------------------
		#region 	VideoFrameRateConstraintsNone
		#if ! __EFFICIENT_MCPP__
		static nuint video_frame_rate_constraints_none;
		#else
		static nuint? video_frame_rate_constraints_none;	
		#endif
		public static nuint VideoFrameRateConstraintsNone 
		{
			get 
			{
				#if __EFFICIENT_MCPP__
			    if  (video_frame_rate_constraints_none != null)
				{
			      return video_frame_rate_constraints_none.Value;
				}
				#endif

				IntPtr RTLD_MAIN_ONLY = Dlfcn.dlopen (null, 0);
				IntPtr ptr = Dlfcn.dlsym (RTLD_MAIN_ONLY, "TWCVideoFrameRateConstraintsNone");
				video_frame_rate_constraints_none = (nuint)Marshal.PtrToStructure (ptr, typeof(nuint));
				Dlfcn.dlclose (RTLD_MAIN_ONLY);


				#if ! __EFFICIENT_MCPP__
				return video_frame_rate_constraints_none;
				#else
			    return video_frame_rate_constraints_none.Value;
				#endif
			}
		}
		#endregion	VideoFrameRateConstraintsNone
		//------------------------------------------------------------------------------------


		//------------------------------------------------------------------------------------
		#region 	AspectRatioConstraintsNone
		#if ! __EFFICIENT_MCPP__
		static AspectRatio aspect_ratio_constraints_none;
		#else
		static AspectRatio? aspect_ratio_constraints_none;	
		#endif
		public static AspectRatio AspectRatioConstraintsNone 
		{
			get 
			{
				#if __EFFICIENT_MCPP__
			    if  (aspect_ratio_constraints_none != null)
				{
			      return aspect_ratio_constraints_none.Value;
				}
				#endif

				IntPtr RTLD_MAIN_ONLY = Dlfcn.dlopen (null, 0);
				IntPtr ptr = Dlfcn.dlsym (RTLD_MAIN_ONLY, "TWCVideoAspectRatioConstraintsNone");
				aspect_ratio_constraints_none = (AspectRatio)Marshal.PtrToStructure (ptr, typeof(AspectRatio));
				Dlfcn.dlclose (RTLD_MAIN_ONLY);


				#if ! __EFFICIENT_MCPP__
				return aspect_ratio_constraints_none;
				#else
			    return aspect_ratio_constraints_none.Value;
				#endif
			}
		}
		#endregion	AspectRatioConstraintsNone
		//------------------------------------------------------------------------------------


		//------------------------------------------------------------------------------------
		#region 	AspectRatio11x9
		#if ! __EFFICIENT_MCPP__
		static AspectRatio aspect_ratio_11x9;
		#else
		static AspectRatio? aspect_ratio_11x9;	
		#endif
		public static AspectRatio AspectRatio11x9 
		{
			get 
			{
				#if __EFFICIENT_MCPP__
			    if  (aspect_ratio_11x9 != null)
				{
			      return aspect_ratio_11x9.Value;
				}
				#endif

				IntPtr RTLD_MAIN_ONLY = Dlfcn.dlopen (null, 0);
				IntPtr ptr = Dlfcn.dlsym (RTLD_MAIN_ONLY, "TWCAspectRatio11x9");
				aspect_ratio_11x9 = (AspectRatio)Marshal.PtrToStructure (ptr, typeof(AspectRatio));
				Dlfcn.dlclose (RTLD_MAIN_ONLY);


				#if ! __EFFICIENT_MCPP__
				return aspect_ratio_11x9;
				#else
			    return aspect_ratio_11x9.Value;
				#endif
			}
		}
		#endregion	AspectRatio11x9
		//------------------------------------------------------------------------------------


		//------------------------------------------------------------------------------------
		#region 	AspectRatio4x3
		#if ! __EFFICIENT_MCPP__
		static AspectRatio aspect_ratio_4x3;
		#else
		static AspectRatio? aspect_ratio_4x3;	
		#endif
		public static AspectRatio AspectRatio4x3 
		{
			get 
			{
				#if __EFFICIENT_MCPP__
			    if  (aspect_ratio_4x3 != null)
				{
			      return aspect_ratio_4x3.Value;
				}
				#endif

				IntPtr RTLD_MAIN_ONLY = Dlfcn.dlopen (null, 0);
				IntPtr ptr = Dlfcn.dlsym (RTLD_MAIN_ONLY, "TWCAspectRatio4x3");
				aspect_ratio_4x3 = (AspectRatio)Marshal.PtrToStructure (ptr, typeof(AspectRatio));
				Dlfcn.dlclose (RTLD_MAIN_ONLY);


				#if ! __EFFICIENT_MCPP__
				return aspect_ratio_4x3;
				#else
			    return aspect_ratio_4x3.Value;
				#endif
			}
		}
		#endregion	AspectRatio4x3
		//------------------------------------------------------------------------------------


		//------------------------------------------------------------------------------------
		#region 	AspectRatio16x9
		#if ! __EFFICIENT_MCPP__
		static AspectRatio aspect_ratio_16x9;
		#else
		static AspectRatio? aspect_ratio_16x9;	
		#endif
		public static AspectRatio AspectRatio16x9 
		{
			get 
			{
				#if __EFFICIENT_MCPP__
			    if  (aspect_ratio_16x9 != null)
				{
			      return aspect_ratio_16x9.Value;
				}
				#endif

				IntPtr RTLD_MAIN_ONLY = Dlfcn.dlopen (null, 0);
				IntPtr ptr = Dlfcn.dlsym (RTLD_MAIN_ONLY, "TWCAspectRatio16x9");
				aspect_ratio_16x9 = (AspectRatio)Marshal.PtrToStructure (ptr, typeof(AspectRatio));
				Dlfcn.dlclose (RTLD_MAIN_ONLY);


				#if ! __EFFICIENT_MCPP__
				return aspect_ratio_16x9;
				#else
			    return aspect_ratio_16x9.Value;
				#endif
			}
		}
		#endregion	AspectRatio16x9
		//------------------------------------------------------------------------------------


	}
}
