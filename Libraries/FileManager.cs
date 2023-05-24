using System;
using System.IO;
using System.Security.Cryptography;
using System.Text;
using Microsoft.AspNetCore.Http.Internal;

namespace net_test.Libraries
{
    public class FileManager
    {
        public static bool validateExtension(string extension)
        {
            bool objReturn = false;

            if( extension != "" ) {
                switch( extension.ToLower() ) {

                    // DOCUMENTOS
                    case ".doc":
                    case ".docx":
                    case ".txt":
                    case ".pdf":
                    case ".rtf":
                        objReturn = true;
                    break;

                    // HOJAS DE CALCULO
                    case ".xls":
                    case ".xlsx":
                        objReturn = true;
                    break;

                    // HOJAS DE CALCULO
                    case ".ppt":
                    case ".pptx":
                    case ".pps":
                    case ".ppsm":
                    case ".xps":
                        objReturn = true;
                    break;

                    // FORMATOS
                    case ".xml":
                    case ".pst":
                        objReturn = true;
                    break;

                    // VIDEOS
                    case ".avi":
                    case ".mp4":
                    case ".mkv":
                    case ".flv":
                    case ".mov":
                    case ".wmv":
                        objReturn = true;
                    break;

                    // AUDIOS
                    case ".mp3":
                    case ".acc":
                    case ".midi":
                    case ".wav":
                    case ".wma":
                        objReturn = true;
                    break;

                    // IMAGENES
                    case ".jpg":
                    case ".gif":
                    case ".bmp":
                    case ".png":
                    case ".tif":
                    case ".jpeg":
                    case ".psd":
                    case ".dwr":
                    case ".dwg":
                    case ".ai":
                        objReturn = true;
                    break;

                    // IMAGENES
                    case ".zip":
                    case ".rar":
                    case ".iso":
                        objReturn = true;
                    break;
                }
            }

            return objReturn;
        }
    
        public static FileRest saveFile(FormFile argFile, string path, bool isBase64 = false, string extension = "") {
            FileRest objReturn = new FileRest();

            if(argFile != null) {
                var _extension = isBase64 ? extension : Path.GetExtension(argFile.FileName);

                if( validateExtension(_extension) ) {

                    string fileName = Encription.MD5() + _extension;
                    using(FileStream fsFile = System.IO.File.Create(path + fileName))
                    {
                        argFile.CopyTo(fsFile);
                        fsFile.Flush();
                        objReturn.Result = true;
                        objReturn.FileName = fileName;
                    }
                }
            }

            return objReturn;
        }

        public class FileRest {
            public bool Result = false;
            public string FileName = null;
        }
    }
}
