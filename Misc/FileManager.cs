using System;
using System.IO;
using System.Diagnostics;
using System.Windows.Forms;

public static class FileManager
{
    /// <summary>
    /// Creates a file at the specified path with optional content.
    /// </summary>
    public static void CreateFile(string filePath, string content = "")
    {
        try
        {
            File.WriteAllText(filePath, content);
            Console.WriteLine($"File created: {filePath}");
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error creating file: {ex.Message}");
        }
    }

    /// <summary>
    /// Deletes a file at the specified path.
    /// </summary>
    public static void DeleteFile(string filePath)
    {
        try
        {
            if (File.Exists(filePath))
            {
                File.Delete(filePath);
                Console.WriteLine($"File deleted: {filePath}");
            }
            else
            {
                Console.WriteLine($"File not found: {filePath}");
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error deleting file: {ex.Message}");
        }
    }

    /// <summary>
    /// Copies a file from the source path to the destination path.
    /// </summary>
    public static void CopyFile(string sourceFilePath, string destinationFilePath, bool overwrite = false)
    {
        try
        {
            File.Copy(sourceFilePath, destinationFilePath, overwrite);
            Console.WriteLine($"File copied from {sourceFilePath} to {destinationFilePath}");
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error copying file: {ex.Message}");
        }
    }

    /// <summary>
    /// Moves a file from the source path to the destination path.
    /// </summary>
    public static void MoveFile(string sourceFilePath, string destinationFilePath)
    {
        try
        {
            File.Move(sourceFilePath, destinationFilePath);
            Console.WriteLine($"File moved from {sourceFilePath} to {destinationFilePath}");
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error moving file: {ex.Message}");
        }
    }

    /// <summary>
    /// Creates a directory at the specified path.
    /// </summary>
    public static void CreateDirectory(string directoryPath)
    {
        try
        {
            if (!Directory.Exists(directoryPath))
            {
                Directory.CreateDirectory(directoryPath);
                Console.WriteLine($"Directory created: {directoryPath}");
            }
            else
            {
                Console.WriteLine($"Directory already exists: {directoryPath}");
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error creating directory: {ex.Message}");
        }
    }

    /// <summary>
    /// Deletes a directory at the specified path, optionally deleting all contents.
    /// </summary>
    public static void DeleteDirectory(string directoryPath, bool recursive = false)
    {
        try
        {
            if (Directory.Exists(directoryPath))
            {
                Directory.Delete(directoryPath, recursive);
                Console.WriteLine($"Directory deleted: {directoryPath}");
            }
            else
            {
                Console.WriteLine($"Directory not found: {directoryPath}");
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error deleting directory: {ex.Message}");
        }
    }

    /// <summary>
    /// Copies all files and directories from the source directory to the destination directory.
    /// </summary>
    public static void CopyDirectory(string sourceDirectory, string destinationDirectory, bool overwrite = true)
    {
        try
        {
            if (!Directory.Exists(destinationDirectory))
            {
                Directory.CreateDirectory(destinationDirectory);
            }

            foreach (string file in Directory.GetFiles(sourceDirectory))
            {
                string destFile = Path.Combine(destinationDirectory, Path.GetFileName(file));
                File.Copy(file, destFile, overwrite);
            }

            foreach (string dir in Directory.GetDirectories(sourceDirectory))
            {
                string destDir = Path.Combine(destinationDirectory, Path.GetFileName(dir));
                CopyDirectory(dir, destDir, overwrite);
            }

            Console.WriteLine($"Directory copied from {sourceDirectory} to {destinationDirectory}");
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error copying directory: {ex.Message}");
        }
    }

    /// <summary>
    /// Opens the specified folder in File Explorer.
    /// </summary>
    public static void OpenFolder(string folderPath)
    {
        try
        {
            if (Directory.Exists(folderPath))
            {
                Process.Start("explorer.exe", folderPath);
            }
            else
            {
                MessageBox.Show("Folder does not exist!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error opening folder: {ex.Message}");
        }
    }

    /// <summary>
    /// Checks if a file exists at the specified path.
    /// </summary>
    public static bool FileExists(string filePath)
    {
        return File.Exists(filePath);
    }

    /// <summary>
    /// Checks if a directory exists at the specified path.
    /// </summary>
    public static bool DirectoryExists(string directoryPath)
    {
        return Directory.Exists(directoryPath);
    }
}
