# Framework de validação da Hubee

Desenvolvemos esse framework para facilitar a validação dos nossos commands/dtos e quiçá nosso domínio!

Nos baseamos na ideia de validação que é disponibilizada no laravel para criar uma ferramenta que valide dinamicamente nossos objetos.

Utilizamos principalmente o [notification pattern](https://martinfowler.com/articles/replaceThrowWithNotification.html) para construir nossa validação.

## Utilização

Para utilizar é muito simples, utilize a interface `IValidatableSchema` criando o método obrigatório `GetSchemaRules()` e nele você deve retornar um objeto anônimo com as validações de cada propriedade separadas por **pipe**, conforme o exemplo:

```c#
using Hubee.Validation.Sdk.Core.Interfaces;
//(...)

public class Cliente: IValidatableSchema
{
    public string Nome { get; set; }
    
    public object GetSchemaRules()
    {
        return new
        {
            Nome = "required|min:10|max:100"
        };
    }
}
```


Sua classe já está configurada para usar a o método `ValidateSchema()` no seu objeto:

```c#
using Hubee.Validation.Sdk.Core.Extensions;
//(...)

public void JustCheckEntity()
{
    var cliente = new Cliente();
    
    var result = cliente.ValidadeSchema();
    
    if (result.IsInvalid())
        throw new Exception(result.Stringify());
}
```

O `ValidateSchema()` retorna um objeto de resultado de validação que possui alguns métodos como:

+ `IsValid()` que verifica se o objeto é valido conforme as rules programadas;
+ `IsInvalid()` que respectivamente verifica se objeto é inválido;
+ `GetErrors()` que retorna a lista de erros;
+ `Stringify()` que converte todos os erros para texto amigável;
+ `StringifyAsList()` que converte todos os erros para uma lista de mensagens amigáveis.


## Rules disponíveis

| Rule | Tipo | Exemplo | Observação |
|:----|:----|:-------|:----------|
| required | todos | "required"|
| min | string, numéricos (int, decimal, double etc) | "required\|min:1" | *min em string validará **length** e em numéricos o **valor***|
| max | string, numéricos (int, decimal, double etc) | "required\|min:1\|max:25" | *max em string validará **length** e em numéricos o **valor***|
