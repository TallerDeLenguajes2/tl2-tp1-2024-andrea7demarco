namespace UtilityLibraries;

public static class StringLibrary
{
    public static bool StartsWithUpper(this string? str)
    {
        if (string.IsNullOrWhiteSpace(str))
            return false;

        char ch = str[0];
        return char.IsUpper(ch);
    }
}

/*La biblioteca de clases, UtilityLibraries.StringLibrary, contiene un método denominado StartsWithUpper. Este método devuelve un valor Boolean que indica si la instancia de cadena actual comienza con un carácter en mayúscula. El estándar Unicode distingue caracteres en mayúsculas de caracteres en minúsculas. El método Char.IsUpper(Char) devuelve true si un carácter está en mayúsculas.

StartsWithUpper se implementa como un método de extensión, de modo que se pueda llamar como si fuera un miembro de la clase String.*/