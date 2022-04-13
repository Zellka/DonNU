using System;

namespace Lab2
{
    public class MockFileService : IFileService
    {
        public bool MergeTemporaryFilesWasCalled { get; private set; }

        public int MergeTemporaryFiles(string dir)
        {
            MergeTemporaryFilesWasCalled = true;
            return 0;
        }
    }
}
