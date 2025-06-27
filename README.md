# BigNumberCalculator

**BigNumberCalculator** é uma aplicação de linha de comando em C# desenvolvida para realizar operações com números inteiros extremamente grandes, lidos de arquivos de entrada. Atualmente, a aplicação suporta apenas a **operação de soma**.

---

## 📁 Estrutura do Projeto

```
BigNumberCalculator/
├── BigNumberCalculator.sln
├── Core/
│   ├── Input/
│   │   ├── numero1.txt   # Contém o primeiro número grande
│   │   └── numero2.txt   # Contém o segundo número grande
│   ├── Output/
│   │   └── resultado.txt # Contém o resultado da operação
│   └── ... (código da aplicação principal)
├── BigNumberCalculator.Tests/
│   └── ... (código de testes)
└── .gitignore
```

---

## 🚀 Como executar o projeto

### 1. Clone o repositório

```bash
git clone git@github.com:elvesbd/BigNumberCalculator.git
cd BigNumberCalculator
```

> 💡 Caso use HTTPS:
>
> ```bash
> git clone https://github.com/elvesbd/BigNumberCalculator.git
> cd BigNumberCalculator
> ```

---

### 2. Restaure os pacotes do projeto

```bash
dotnet restore
```

---

### 3. Compile a aplicação

```bash
dotnet build
```

---

### 4. Verifique os arquivos de entrada

A pasta `Core/Input/` já contém os arquivos necessários:

- `numero1.txt` → Ex: `123456789123456789123456789`
- `numero2.txt` → Ex: `987654321987654321987654321`

---

### 5. Execute o projeto

```bash
dotnet run --project Core
```

---

## ✅ O que a aplicação faz

- Lê dois números inteiros muito grandes dos arquivos `Core/Input/numero1.txt` e `Core/Input/numero2.txt`
- Realiza a **soma** dos dois números usando uma lógica própria (sem `BigInteger`)
- Exibe uma interface simples no terminal para interação
- Escreve o resultado no arquivo `Core/Output/resultado.txt`
- Exibe o tempo de execução da operação

---

## 💡 Exemplo de uso

### Arquivos de entrada:

`Core/Input/numero1.txt`:
```
999999999999999999999999
```

`Core/Input/numero2.txt`:
```
1
```

---

### Resultado gerado em `Core/Output/resultado.txt`:

```
=== Resultado da Soma ===

Número 1: 999999999999999999999999
Número 2: 1

Resultado: 1000000000000000000000000
Tempo de execução: 00:00:00.0001234
```

---

## 🧪 Testes

O projeto possui uma estrutura inicial para testes automatizados. Para executá-los:

```bash
dotnet test
```

---

## 🛠 Tecnologias utilizadas

- C# 12 / .NET 8
- Programação orientada a objetos
- Manipulação de arquivos e entrada/saída no terminal
- Estrutura de testes com xUnit (em desenvolvimento)

---

## 📄 Licença

Este projeto está licenciado sob a [MIT License](LICENSE).

---

## 🙋 Autor

Desenvolvido por **Elves Damasceno**  
🔗 [github.com/elvesbd](https://github.com/elvesbd)