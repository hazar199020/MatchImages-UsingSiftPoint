/*
* MATLAB Compiler: 4.13 (R2010a)
* Date: Wed Jun 27 14:15:51 2012
* Arguments: "-B" "macro_default" "-W" "dotnet:Pro,Matlab,0.0,private" "-T" "link:lib"
* "-d" "C:\Users\Nostalgia\Documents\Visual Studio 2010\Projects\Project\Project\Pro\src"
* "-w" "enable:specified_file_mismatch" "-w" "enable:repeated_file" "-w"
* "enable:switch_ignored" "-w" "enable:missing_lib_sentinel" "-w" "enable:demo_license"
* "-v"
* "class{Matlab:C:\Users\Nostalgia\Documents\MATLAB\match.m,C:\Users\Nostalgia\Documents\M
* ATLAB\sift.m}" 
*/
using System;
using System.Reflection;
using System.IO;
using MathWorks.MATLAB.NET.Arrays;
using MathWorks.MATLAB.NET.Utility;
using MathWorks.MATLAB.NET.ComponentData;

#if SHARED
[assembly: System.Reflection.AssemblyKeyFile(@"")]
#endif

namespace ProNative
{
  /// <summary>
  /// The Matlab class provides a CLS compliant, Object (native) interface to the
  /// M-functions contained in the files:
  /// <newpara></newpara>
  /// C:\Users\Nostalgia\Documents\MATLAB\match.m
  /// <newpara></newpara>
  /// C:\Users\Nostalgia\Documents\MATLAB\sift.m
  /// <newpara></newpara>
  /// deployprint.m
  /// <newpara></newpara>
  /// printdlg.m
  /// </summary>
  /// <remarks>
  /// @Version 0.0
  /// </remarks>
  public class Matlab : IDisposable
  {
    #region Constructors

    /// <summary internal= "true">
    /// The static constructor instantiates and initializes the MATLAB Compiler Runtime
    /// instance.
    /// </summary>
    static Matlab()
    {
      if (MWMCR.MCRAppInitialized)
      {
        Assembly assembly= Assembly.GetExecutingAssembly();

        string ctfFilePath= assembly.Location;

        int lastDelimiter= ctfFilePath.LastIndexOf(@"\");

        ctfFilePath= ctfFilePath.Remove(lastDelimiter, (ctfFilePath.Length - lastDelimiter));

        string ctfFileName = MCRComponentState.MCC_Pro_name_data + ".ctf";

        Stream embeddedCtfStream = null;

        String[] resourceStrings = assembly.GetManifestResourceNames();

        foreach (String name in resourceStrings)
        {
          if (name.Contains(ctfFileName))
          {
            embeddedCtfStream = assembly.GetManifestResourceStream(name);
            break;
          }
        }
        mcr= new MWMCR(MCRComponentState.MCC_Pro_name_data,
                       MCRComponentState.MCC_Pro_root_data,
                       MCRComponentState.MCC_Pro_public_data,
                       MCRComponentState.MCC_Pro_session_data,
                       MCRComponentState.MCC_Pro_matlabpath_data,
                       MCRComponentState.MCC_Pro_classpath_data,
                       MCRComponentState.MCC_Pro_libpath_data,
                       MCRComponentState.MCC_Pro_mcr_application_options,
                       MCRComponentState.MCC_Pro_mcr_runtime_options,
                       MCRComponentState.MCC_Pro_mcr_pref_dir,
                       MCRComponentState.MCC_Pro_set_warning_state,
                       ctfFilePath, embeddedCtfStream, true);
      }
      else
      {
        throw new ApplicationException("MWArray assembly could not be initialized");
      }
    }


    /// <summary>
    /// Constructs a new instance of the Matlab class.
    /// </summary>
    public Matlab()
    {
    }


    #endregion Constructors

    #region Finalize

    /// <summary internal= "true">
    /// Class destructor called by the CLR garbage collector.
    /// </summary>
    ~Matlab()
    {
      Dispose(false);
    }


    /// <summary>
    /// Frees the native resources associated with this object
    /// </summary>
    public void Dispose()
    {
      Dispose(true);

      GC.SuppressFinalize(this);
    }


    /// <summary internal= "true">
    /// Internal dispose function
    /// </summary>
    protected virtual void Dispose(bool disposing)
    {
      if (!disposed)
      {
        disposed= true;

        if (disposing)
        {
          // Free managed resources;
        }

        // Free native resources
      }
    }


    #endregion Finalize

    #region Methods

    /// <summary>
    /// Provides a single output, 0-input Objectinterface to the match M-function.
    /// </summary>
    /// <remarks>
    /// M-Documentation:
    /// For each descriptor in the first image, select its match to second image.
    /// </remarks>
    /// <returns>An Object containing the first output argument.</returns>
    ///
    public Object match()
    {
      return mcr.EvaluateFunction("match", new Object[]{});
    }


    /// <summary>
    /// Provides a single output, 1-input Objectinterface to the match M-function.
    /// </summary>
    /// <remarks>
    /// M-Documentation:
    /// For each descriptor in the first image, select its match to second image.
    /// </remarks>
    /// <param name="des1">Input argument #1</param>
    /// <returns>An Object containing the first output argument.</returns>
    ///
    public Object match(Object des1)
    {
      return mcr.EvaluateFunction("match", des1);
    }


    /// <summary>
    /// Provides a single output, 2-input Objectinterface to the match M-function.
    /// </summary>
    /// <remarks>
    /// M-Documentation:
    /// For each descriptor in the first image, select its match to second image.
    /// </remarks>
    /// <param name="des1">Input argument #1</param>
    /// <param name="des2">Input argument #2</param>
    /// <returns>An Object containing the first output argument.</returns>
    ///
    public Object match(Object des1, Object des2)
    {
      return mcr.EvaluateFunction("match", des1, des2);
    }


    /// <summary>
    /// Provides the standard 0-input Object interface to the match M-function.
    /// </summary>
    /// <remarks>
    /// M-Documentation:
    /// For each descriptor in the first image, select its match to second image.
    /// </remarks>
    /// <param name="numArgsOut">The number of output arguments to return.</param>
    /// <returns>An Array of length "numArgsOut" containing the output
    /// arguments.</returns>
    ///
    public Object[] match(int numArgsOut)
    {
      return mcr.EvaluateFunction(numArgsOut, "match", new Object[]{});
    }


    /// <summary>
    /// Provides the standard 1-input Object interface to the match M-function.
    /// </summary>
    /// <remarks>
    /// M-Documentation:
    /// For each descriptor in the first image, select its match to second image.
    /// </remarks>
    /// <param name="numArgsOut">The number of output arguments to return.</param>
    /// <param name="des1">Input argument #1</param>
    /// <returns>An Array of length "numArgsOut" containing the output
    /// arguments.</returns>
    ///
    public Object[] match(int numArgsOut, Object des1)
    {
      return mcr.EvaluateFunction(numArgsOut, "match", des1);
    }


    /// <summary>
    /// Provides the standard 2-input Object interface to the match M-function.
    /// </summary>
    /// <remarks>
    /// M-Documentation:
    /// For each descriptor in the first image, select its match to second image.
    /// </remarks>
    /// <param name="numArgsOut">The number of output arguments to return.</param>
    /// <param name="des1">Input argument #1</param>
    /// <param name="des2">Input argument #2</param>
    /// <returns>An Array of length "numArgsOut" containing the output
    /// arguments.</returns>
    ///
    public Object[] match(int numArgsOut, Object des1, Object des2)
    {
      return mcr.EvaluateFunction(numArgsOut, "match", des1, des2);
    }


    /// <summary>
    /// Provides a single output, 0-input Objectinterface to the sift M-function.
    /// </summary>
    /// <remarks>
    /// M-Documentation:
    /// Load image
    /// </remarks>
    /// <returns>An Object containing the first output argument.</returns>
    ///
    public Object sift()
    {
      return mcr.EvaluateFunction("sift", new Object[]{});
    }


    /// <summary>
    /// Provides a single output, 1-input Objectinterface to the sift M-function.
    /// </summary>
    /// <remarks>
    /// M-Documentation:
    /// Load image
    /// </remarks>
    /// <param name="imageFile">Input argument #1</param>
    /// <returns>An Object containing the first output argument.</returns>
    ///
    public Object sift(Object imageFile)
    {
      return mcr.EvaluateFunction("sift", imageFile);
    }


    /// <summary>
    /// Provides the standard 0-input Object interface to the sift M-function.
    /// </summary>
    /// <remarks>
    /// M-Documentation:
    /// Load image
    /// </remarks>
    /// <param name="numArgsOut">The number of output arguments to return.</param>
    /// <returns>An Array of length "numArgsOut" containing the output
    /// arguments.</returns>
    ///
    public Object[] sift(int numArgsOut)
    {
      return mcr.EvaluateFunction(numArgsOut, "sift", new Object[]{});
    }


    /// <summary>
    /// Provides the standard 1-input Object interface to the sift M-function.
    /// </summary>
    /// <remarks>
    /// M-Documentation:
    /// Load image
    /// </remarks>
    /// <param name="numArgsOut">The number of output arguments to return.</param>
    /// <param name="imageFile">Input argument #1</param>
    /// <returns>An Array of length "numArgsOut" containing the output
    /// arguments.</returns>
    ///
    public Object[] sift(int numArgsOut, Object imageFile)
    {
      return mcr.EvaluateFunction(numArgsOut, "sift", imageFile);
    }


    /// <summary>
    /// This method will cause a MATLAB figure window to behave as a modal dialog box.
    /// The method will not return until all the figure windows associated with this
    /// component have been closed.
    /// </summary>
    /// <remarks>
    /// An application should only call this method when required to keep the
    /// MATLAB figure window from disappearing.  Other techniques, such as calling
    /// Console.ReadLine() from the application should be considered where
    /// possible.</remarks>
    ///
    public void WaitForFiguresToDie()
    {
      mcr.WaitForFiguresToDie();
    }



    #endregion Methods

    #region Class Members

    private static MWMCR mcr= null;

    private bool disposed= false;

    #endregion Class Members
  }
}
