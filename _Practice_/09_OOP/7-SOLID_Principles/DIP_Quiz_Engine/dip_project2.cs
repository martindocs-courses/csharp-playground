
namespace OOP_SOLID_Principles.DIP_Quiz_Engine
{
    public interface IQuizRepository{
        public void ConnectToRepository();
    }

    public class JsonQuizRepository : IQuizRepository
    {
        public void ConnectToRepository()
        {
            Console.WriteLine("Connect to JsonQuiz Repository");
        }
    }
    public class XmlQuizRepository : IQuizRepository
    {
        public void ConnectToRepository()
        {
            Console.WriteLine("Connect to XmlQuiz Repository");            
        }
    }
    public class DbQuizRepository : IQuizRepository
    {
        public void ConnectToRepository()
        {
            Console.WriteLine("Connect to DbQuiz Repository");     
        }
    }

    public class QuizEngine{
        private readonly IQuizRepository _quizRepository;

        public QuizEngine(IQuizRepository quiz)
        {
            _quizRepository = quiz;
        }

        public void Connect(){
            _quizRepository.ConnectToRepository();
        }

    }
}
