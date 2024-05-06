namespace WebApplication1.Models
{
    public class TaskListModel
    {

        //
        //

        static List<TaskModel> taskStore = new List<TaskModel>()
        {
            new TaskModel("1", "タスク1"),
            new TaskModel("2", "タスク1"),
        };

        //
        //

        public TaskListModel(List<TaskModel>? tasks)
        {
            TaskList = new List<TaskModel>();
            if (tasks != null)
            {
                TaskList = tasks;
            }
        }

        //
        //

        public List<TaskModel> TaskList { get; set; }

        public static TaskListModel getAll() {
            return new TaskListModel(taskStore); 
        }

        public static TaskModel? getById(string id) {
            return taskStore.Find(e => e.Id == id);
        }

        public static TaskListModel getOpenTasks()
        {
            return new TaskListModel(taskStore.FindAll(e => !e.Done));
        }

        public static void toDone(string Id)
        {
            List<TaskModel> newTaskModels = [];
            foreach (TaskModel task in taskStore)
            {
                if (task.Id.Equals(Id))
                {
                    newTaskModels.Add(new TaskModel(task.Id, task.Name, true));
                } else
                {
                    newTaskModels.Add(task);
                }
            }
            taskStore = newTaskModels;
        }
    }
}
