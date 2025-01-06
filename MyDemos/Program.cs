using MyDemos;

Console.WriteLine("Start");

var wordToPdf = new WordToPdfConvertor();
wordToPdf.Convert("abc.docx", "abc.pdf");

//Load test on AES encryption
//int numberOfRequests = 1000000;
//await LoadTest.RunLoadTest(numberOfRequests);

////await ReaderWriterLockSlimDemo.Test();

//Console.WriteLine("Finished...");

//Console.ReadLine();
