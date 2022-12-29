namespace ComplexNumber;
public class Complex{
    private int real;
    private int imaginary;

    public Complex(){
        this.real=0;
        this.imaginary=0;
    }
    
    public Complex(int real, int imag){
        this.real = real;
        this.imaginary=imag;
    }
//Property Syntax
    public int Real{
        get{return this.real;}
        set{this.real=value;}
    }
    public int Imaginary{
        get{return this.imaginary;}
        set{this.imaginary=value;}
        }
    public static Complex operator+ (Complex c1, Complex c2){
        Complex temp = new Complex();
        temp.Real = c1.Real+c2.Real;
        temp.Imaginary=c1.Imaginary+c2.Imaginary;
        return temp;

    }
}
