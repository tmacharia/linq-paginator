namespace Tests
{
    public class TestBase
    {
        protected static int GetPages(int total, int perpage)
        {
            int ans = total / perpage;
            ans += (total % perpage) > 0 ? 1 : 0;
            return ans;
        }
    }
}