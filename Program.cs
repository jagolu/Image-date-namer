try
{
    ImageDater.IDApp.IAapplication app = new ImageDater.IDApp.IAapplication();
    app.run();
}catch (Exception ex)
{
    Console.Error.WriteLine("Error-->" + ex.Message);
    Console.Read();
}