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
		#region 	TVIVideoConstraintsAspectRatioNone
		#if ! __EFFICIENT_MCPP__
		static CMVideoDimensions video_constraints_aspect_ratio_none;
		#else
		static CMVideoDimensions? video_constraints_aspect_ratio_none;	
		#endif
		public static CMVideoDimensions VideoConstraintsAspectRatioNone 
		{
			get 
			{
				#if __EFFICIENT_MCPP__
			    if  (video_constraints_aspect_ratio_none != null)
				{
			      return video_constraints_aspect_ratio_none.Value;
				}
				#endif

				IntPtr RTLD_MAIN_ONLY = Dlfcn.dlopen (null, 0);
				IntPtr ptr = Dlfcn.dlsym (RTLD_MAIN_ONLY, "TVIVideoConstraintsAspectRatioNone");
				video_constraints_aspect_ratio_none = (CMVideoDimensions)Marshal.PtrToStructure (ptr, typeof(CMVideoDimensions));
				Dlfcn.dlclose (RTLD_MAIN_ONLY);


				#if ! __EFFICIENT_MCPP__
				return video_constraints_aspect_ratio_none;
				#else
			    return video_constraints_aspect_ratio_none.Value;
				#endif
			}
		}
		#endregion	TVIVideoConstraintsAspectRatioNone
		//------------------------------------------------------------------------------------

		//------------------------------------------------------------------------------------
		#region 	TVIAspectRatio11x9
		#if ! __EFFICIENT_MCPP__
		static CMVideoDimensions video_constraints_aspect_ratio_11x9;
		#else
		static CMVideoDimensions? video_constraints_aspect_ratio_11x9;	
		#endif
		public static CMVideoDimensions VideoConstraintsAspectRatio11x9 
		{
			get 
			{
				#if __EFFICIENT_MCPP__
			    if  (video_constraints_aspect_ratio_11x9 != null)
				{
			      return video_constraints_aspect_ratio_11x9.Value;
				}
				#endif

				IntPtr RTLD_MAIN_ONLY = Dlfcn.dlopen (null, 0);
				IntPtr ptr = Dlfcn.dlsym (RTLD_MAIN_ONLY, "TVIAspectRatio11x9");
				video_constraints_aspect_ratio_11x9 = (CMVideoDimensions)Marshal.PtrToStructure (ptr, typeof(CMVideoDimensions));
				Dlfcn.dlclose (RTLD_MAIN_ONLY);


				#if ! __EFFICIENT_MCPP__
				return video_constraints_aspect_ratio_11x9;
				#else
			    return video_constraints_aspect_ratio_11x9.Value;
				#endif
			}
		}
		#endregion	TVIAspectRatio11x9
		//------------------------------------------------------------------------------------

		//------------------------------------------------------------------------------------
		#region 	TVIAspectRatio4x3
		#if ! __EFFICIENT_MCPP__
		static CMVideoDimensions video_constraints_aspect_ratio_4x3;
		#else
		static CMVideoDimensions? video_constraints_aspect_ratio_4x3;	
		#endif
		public static CMVideoDimensions VideoConstraintsAspectRatio4x3 
		{
			get 
			{
				#if __EFFICIENT_MCPP__
			    if  (video_constraints_aspect_ratio_4x3 != null)
				{
			      return video_constraints_aspect_ratio_4x3.Value;
				}
				#endif

				IntPtr RTLD_MAIN_ONLY = Dlfcn.dlopen (null, 0);
				IntPtr ptr = Dlfcn.dlsym (RTLD_MAIN_ONLY, "TVIAspectRatio11x9");
				video_constraints_aspect_ratio_4x3 = (CMVideoDimensions)Marshal.PtrToStructure (ptr, typeof(CMVideoDimensions));
				Dlfcn.dlclose (RTLD_MAIN_ONLY);


				#if ! __EFFICIENT_MCPP__
				return video_constraints_aspect_ratio_4x3;
				#else
			    return video_constraints_aspect_ratio_4x3.Value;
				#endif
			}
		}
		#endregion	TVIAspectRatio11x9
		//------------------------------------------------------------------------------------
	}
}
