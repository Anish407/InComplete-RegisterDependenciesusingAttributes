namespace ConsoleApp1
{
    [RegisterScoped]
    public class NoRegistration : IM1
    {
        public void M1()
        {

        }
    }

    [RegisterScoped(RegisteredTypes = new Type[] { typeof(IM1) })]
    public class SampleScoped : IM1, IM2
    {
        public void M1()
        {

        }

        public void M2()
        {

        }
    }

    [ResgisterTransient(RegisteredTypes = new Type[] { typeof(IM1) })]
    public class SampleTransient : IM1, IM2
    {
        public void M1()
        {

        }

        public void M2()
        {

        }
    }

    [RegisterSingleton(RegisteredTypes = new Type[] { typeof(IM1) })]
    public class SampleSingleton : IM1, IM2
    {
        public void M1()
        {

        }

        public void M2()
        {

        }
    }

    

}
