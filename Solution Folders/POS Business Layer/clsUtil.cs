using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Diagnostics;
using System.Security.Cryptography;

namespace CS_BusinessLayer
{
    
        public static class clsUtil
        {
            public static string ExceptionMessageToString(Exception ex)
            {
                // this function will convert the exception message to string
                // it will return the string representation of the exception message
                string exceptionMessage = ex.Message + Environment.NewLine + ex.StackTrace;
                return exceptionMessage;
            }
            public static void WriteToRegistry(string EventMessage, EventLogEntryType eventLogEntryType,string SourceName , string LogName )
            {
                // this function will write the exception message to the registry
                // it will return true if the operation is successful, otherwise false

                
                try
                {
                    // Open the registry key
#pragma warning disable CA1416 // Validate platform compatibility
                    if (!EventLog.SourceExists(SourceName))
                    {
                        EventLog.CreateEventSource(SourceName, LogName);


                    }
                    EventLog.WriteEntry(SourceName, EventMessage, eventLogEntryType);
#pragma warning restore CA1416 // Validate platform compatibility

                }
                catch (Exception ex)
                {

                    EventLog.WriteEntry(SourceName, "Exception in Log Exception Method" + ex.Message, EventLogEntryType.Error);

                }

            }
            public static bool CreateFolderIfDoesNotExist(string FolderPath)
            {

                // Check if the folder exists
                if (!Directory.Exists(FolderPath))
                {
                    try
                    {
                        // If it doesn't exist, create the folder
                        Directory.CreateDirectory(FolderPath);
                        return true;
                    }
                    catch (Exception ex)
                    {

                        return false;
                    }
                }

                return true;

            }

            public static string ReplaceFileNameWithGUID(string sourceFile)
            {
                // Full file name. Change your file name   
                string fileName = sourceFile;
                FileInfo fi = new FileInfo(fileName);
                string extn = fi.Extension;
                return Guid.NewGuid() + extn;

            }

            public static bool CopyImageToProjectImagesFolder(ref string sourceFile,string DestinationFolder)
            {
                // this funciton will copy the image to the
                // project images foldr after renaming it
                // with GUID with the same extention, then it will update the sourceFileName with the new name.

                
                if (!CreateFolderIfDoesNotExist(DestinationFolder))
                {
                    return false;
                }

                string destinationFile = DestinationFolder + ReplaceFileNameWithGUID(sourceFile);
                try
                {
                    File.Copy(sourceFile, destinationFile, true);

                }
                catch (IOException iox)
                {

                    return false;
                }

                sourceFile = destinationFile;
                return true;
            }
            public static string EncryptePassword(string Password)
            {
                // this function will encrypt the password using SHA256
                // and return the encrypted password as a string
                using (SHA256 sha256Hash = SHA256.Create())
                {
                    // ComputeHash - returns byte array
                    byte[] bytes = sha256Hash.ComputeHash(Encoding.UTF8.GetBytes(Password));
                    // Convert byte array to a string

                    return BitConverter.ToString(bytes).Replace("-", "").ToLower();
                }
            }
        }
    }


