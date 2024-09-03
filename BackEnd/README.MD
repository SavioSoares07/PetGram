## Pré-requisitos

Antes de instalar e executar o projeto, certifique-se de que você tem o seguinte instalado em sua máquina:

- [.NET SDK](https://dotnet.microsoft.com/download) (versão 6.0 ou superior)
- Um editor de código, como [Visual Studio](https://visualstudio.microsoft.com/) ou [Visual Studio Code](https://code.visualstudio.com/)

## Instalação
git clone https://github.com/SavioSoares07/PetGram



```bash
  cd petgram
  dotnet restore
  dotnet run


```


## Documentação da API

```http
  POST /api/account
```



| Parâmetro   | Tipo       | Descrição                                   |
| :---------- | :--------- | :------------------------------------------ |
| `user`      | `string` | Nome do usuário |
| `pet`      | `string` | Nome do Pet |
| `email`      | `string` | Email do usuário |
| `password`      | `string` | Senha do usuário |


