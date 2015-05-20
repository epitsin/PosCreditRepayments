using System;

namespace POSCreditRepayments.Web.Controllers
{
    public class Xirr
    {
        public const double Tol = 0.001;

        public delegate double Fx(double x);

        public static Fx ComposeFunctions(Fx f1, Fx f2)
        {
            return(double x) => f1(x) + f2(x);
        }

        public static Fx DfXirr(double p, double dt, double dt0)
        {
            return(double x) => (1.0 / 365.0) * (dt0 - dt) * p * Math.Pow((x + 1.0), (((dt0 - dt) / 365.0) - 1.0));
        }

        public static Fx FXirr(double p, double dt, double dt0)
        {
            return(double x) => p * Math.Pow((1.0 + x), ((dt0 - dt) / 365.0));
        }

        public static double NewtonsMethod(double guess, Fx f, Fx df)
        {
            double x0 = guess;
            double x1 = 0.0;
            double err = 1e+100;

            while (err > Tol)
            {
                x1 = x0 - f(x0) / df(x0);
                err = Math.Abs(x1 - x0);
                x0 = x1;
            }

            return x0;
        }

        public static Fx TotalDfXirr(double[] payments, double[] days)
        {
            Fx resf = (double x) => 0.0;

            for (int i = 0; i < payments.Length; i++)
            {
                resf = ComposeFunctions(resf, DfXirr(payments[i], days[i], days[0]));
            }

            return resf;
        }

        public static Fx TotalFXirr(double[] payments, double[] days)
        {
            Fx resf = (double x) => 0.0;

            for (int i = 0; i < payments.Length; i++)
            {
                resf = ComposeFunctions(resf, FXirr(payments[i], days[i], days[0]));
            }

            return resf;
        }
    }
}