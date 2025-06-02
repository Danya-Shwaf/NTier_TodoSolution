namespace NTierTodoApp.Models
{
  /// <summary>
  //.يمثل نموذج المهمة 
  /// </summary>
  public class TaskItem
    {
      public int Id { get; set; }
      public required string Title { get; set; }
      public bool IsComplete { get; set; }
    }
}