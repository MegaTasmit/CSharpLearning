namespace ToDoList_v1
{
    public class IssueList
    {
        private Issue[] _issueList;

        public IssueList(int maxLength)
        {
            _issueList = new Issue[maxLength];

            _issueList[0] = new Issue("Расписать программу по классам");
            _issueList[1] = new Issue("Создать основные классы программы");
            _issueList[2] = new Issue("Создать основной функционал программы");
            _issueList[3] = new Issue("Прротестировать работу программы");
            _issueList[4] = new Issue("Оптимизировать код");
            _issueList[5] = new Issue("Похвалить себя =)");

            _issueList[2].Status = Status.В_работе;
            _issueList[5].Status = Status.В_работе;
        }

        public Issue[] GetIssues()
        {
            Issue[] result = new Issue[GetIssuesCount()];

            for (int i = 0; i < result.Length; i++)
            {
                result[i] = _issueList[i];
            }

            return result;
        }

        public void AddIssue(string title)
        {
            _issueList[GetIssuesCount()] = new Issue(title);

        }

        public void DeleteIssue(int index)
        {
            _issueList[index] = null;

            for (int i = 0; i < _issueList.Length; i++)
            {
                if (_issueList[i] == null && _issueList[i + 1] != null)
                    (_issueList[i], _issueList[i + 1]) = (_issueList[i + 1], _issueList[i]);

                if (_issueList[i] == null && _issueList[i + 1] == null)
                    break;
            }
        }

        public void EditTitle(string title, int index)
        {
            _issueList[index].Title = title;
            _issueList[index].DateTime = DateTime.Now;
        }

        public void TakeIssue(int index)
        {
            _issueList[index].Status = Status.В_работе;
            _issueList[index].DateTime = DateTime.Now;
        }

        public void CompleteIssue(int index)
        {
            _issueList[index].Status = Status.Выполнена;
            _issueList[index].DateTime = DateTime.Now;
        }

        public int GetIssuesCount()
        {
            int count = 0;

            for (int i = 0; i < _issueList.Length; i++)
            {
                if (_issueList[i] == null)
                    break;
                count++;
            }

            return count;
        }
    }
}