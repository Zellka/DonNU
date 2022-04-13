using System;

namespace Lab2
{
    public class ReportViewer
    {
        public IFileService fileService { get; private set; }

        public int BlockCount { get; private set; }

        public ReportViewer()
        {
            fileService = new FileService();
        }
        public ReportViewer(IFileService fs)
        {
            fileService = fs;
        }
        public void PrepareDate(string path)
        {
            int result = fileService.MergeTemporaryFiles(path);
            if (result == 0) return;
            BlockCount = result;
        }
    }
}
