using System;
using System.Collections.Generic;
using System.Text;
using System.IO;

namespace Lab2
{
    public class FileService : IFileService
    {
        private IFile file;

        private readonly string backup = "backup.tmp";

        public FileService()
        {
            file = new StubFile();
        }

        public FileService(IFile fs)
        {
            if (fs is null) throw new ArgumentNullException();
            file = fs;
        }

        public IFile FileSystem
        {
            set
            {
                if (value is null) throw new ArgumentNullException();
                file = value;
            }
            get
            {
                return file;
            }
        }

        public int MergeTemporaryFiles(string dir)
        {

            if (dir is null) throw new ArgumentNullException(); 
            if (!file.Exist(dir)) throw new DirectoryNotFoundException();

            string[] files = file.GetFiles(dir);

            if (files.Length == 0)
                return 0;

            byte[][] buff = GetFilesData(files);
            DeleteFiles(files);
            CreateBackup(Path.Combine(dir, backup), buff);
            return files.Length;
        }

        void CreateBackup(string dir, byte[][] buff)
        {
            int bytes = 0;
            for (int i = 0; i < buff.Length; i++)
                bytes += buff[i].Length;

            byte[] b = new byte[bytes];
            for (int i = 0, counter = 0; i < buff.Length; i++)
            {
                for (int j = 0; j < buff[i].Length; j++, counter++)
                    b[counter] = buff[i][j];
            }
            file.CreateFile(dir, b);
        }

        byte[][] GetFilesData(string[] files)
        {
            byte[][] data = new byte[files.Length][];
            for (int i = 0; i < files.Length; i++)
                data[i] = GetFileData(files[i]);
            return data;
        }

        byte[] GetFileData(string file)
        {
            return this.file.GetFile(file);
        }

        void DeleteFiles(string[] files)
        {
            foreach (string file in files)
                DeleteFile(file);
        }

        void DeleteFile(string file) 
        { 
            this.file.DeleteFile(file); 
        }
    }
}
