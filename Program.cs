try
{
    ImageDater.IDApp.IAapplication app = new ImageDater.IDApp.IAapplication();
    app.run();
    //app.run2(ImageDater.Files.PathNameBehavior.IMG_DATE);
}
catch (Exception ex)
{
    Console.Error.WriteLine("Error-->" + ex.Message);
    Console.Read();
}