using System;
using System.IO;
using System.Text;
using System.Runtime.InteropServices;
using System.Drawing;

namespace pg_class.pg_classes
{
    /// <summary>
    /// Класс файла документов 
    /// </summary>
    public partial class doc_file
    {
        #region ФУНКЦИИ Win32 API

        /// <remarks>Структура Win32 API</remarks>
        [StructLayout(LayoutKind.Sequential)]

        public struct SHFILEINFO
        {
            /// <summary>
            /// Хэндел иконки
            /// </summary>
            public IntPtr hIcon;
            /// <summary>
            /// Индекс иконки
            /// </summary>
            public Int32 iIcon;
            /// <summary>
            /// Атрибуты иконки
            /// </summary>
            public uint dwAttributes;
            /// <summary>
            /// Атрибуты иконки
            /// </summary>
            [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 260)]

            public string szDisplayName;
            /// <summary>
            /// Атрибуты иконки
            /// </summary>
            [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 80)]

            public string szTypeName;

        };

        /// <summary>
        /// Класс доступа к Win32 API
        /// </summary>
        public class Win32
        {
            /// <summary>
            /// Константа типа возвращаемых данных
            /// </summary>
            public const uint SHGFI_ICON = 0x100;
            /// <summary>
            /// Константа определяющая размер иконки
            /// </summary>
            public const uint SHGFI_LARGEICON = 0x0; // 'Large icon
                                                     /// <summary>
                                                     /// Константа определяющая размер иконки
                                                     /// </summary>
            public const uint SHGFI_SMALLICON = 0x1; // 'Small icon

            /// <summary>
            /// Win32 API функция доступа к информации о файле
            /// </summary>
            [DllImport("shell32.dll")]

            public static extern IntPtr SHGetFileInfo(string pszPath, uint dwFileAttributes, ref SHFILEINFO psfi, uint cbSizeFileInfo, uint uFlags);

            /// <summary>
            /// Win32 API метод освобождения ресурсов
            /// </summary>
            [System.Runtime.InteropServices.DllImport("user32.dll", CharSet = CharSet.Auto)]
            public extern static bool DestroyIcon(IntPtr handle);

        }

        #endregion


        /// <summary>
        /// Метод возвращает иконку файла
        /// </summary>
        public Icon doc_file_Icon()
        {

            StringBuilder sb = new StringBuilder();
            
            sb.Append(Path.GetTempPath());
            System.IO.Directory.CreateDirectory(sb.ToString());
            sb.Append(@"tmp");
            sb.Append(Extension);

            IntPtr hImgLarge; //the handle to the system image list
            SHFILEINFO shinfo = new SHFILEINFO();

            if (File.Exists(sb.ToString()) == false)
            {
                File.Create(sb.ToString());
            }

            //Use this to get the small Icon
            hImgLarge = Win32.SHGetFileInfo(sb.ToString(), 0, ref shinfo, (uint)Marshal.SizeOf(shinfo), Win32.SHGFI_ICON | Win32.SHGFI_SMALLICON);
            //Use this to get the large Icon
            //hImgLarge = SHGetFileInfo(fName, 0, 
            //	ref shinfo, (uint)Marshal.SizeOf(shinfo), 
            //	Win32.SHGFI_ICON | Win32.SHGFI_LARGEICON);

            //The icon is returned in the hIcon member of the shinfo struct
            System.Drawing.Icon myIcon = System.Drawing.Icon.FromHandle(shinfo.hIcon);
            Win32.DestroyIcon(shinfo.hIcon);
            //   System.IO.File.Delete(fName);
            return myIcon;
        }
    }
}
