/*La inyección de dependencias se rige por el principiop de inversión de dependencias. Este principio propone evitar las dependencias
rígidas entre los componentes, utilizando las siguiente técnicas:
    -Utilizar abstracciones (interfaces)
    -Hacer que una clase reciba referencias a los componentes que necesita para funcionar 
Un sistema de inyección de dependencias es el encargado de instanciar las clases que necesitemos y suministrarnos ("inyectar") 
las dependencias enviando los parámetros oportunos al constructor.

Existe otra manera de inyectar dependencias haciendo uso del atributo [Dependency]

En cualquiera de las dos opciones evitamos el uso de implemetaciones concretas mediante el uso de 
*/

public class HelloWorldService : IHelloWorldService
{
    public string GetHelloWorld()
    {
        return "Hello World!";
    }
}

public interface IHelloWorldService
{
    string GetHelloWorld();
}