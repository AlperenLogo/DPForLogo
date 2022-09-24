// See https://aka.ms/new-console-template for more information
Console.WriteLine("Hello, World!");
Invoker invoker = new Invoker();
invoker.AddCommand(new SendMailCommand());
invoker.ExecuteCommands();

public interface ICommand
{
    void Execute();


}

public interface IUndoable
{
    void UnDo();
}
public class Invoker
{
    private List<ICommand> commands = new List<ICommand>();

    //Loglama -> Validasyon
    public void AddCommand(ICommand command) => commands.Add(command);
    public void RemoveCommand(ICommand command) => commands.Remove(command);
    public void ClearAllCommands() => commands.Clear();
    public void ExecuteCommands() => commands.ForEach(c => c.Execute());
}

public class SendMailCommand : ICommand
{
    public void Execute()
    {
        Console.WriteLine("Eposta gönderildi");
    }


}