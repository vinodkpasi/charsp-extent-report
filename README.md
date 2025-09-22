# 🚀 UI Test Automation Framework (C# + Selenium + MSTest)

This repository contains an automated UI testing framework built with **C#**, **Selenium WebDriver**, and **MSTest**.  
It follows the **Page Object Model (POM)** design pattern for scalability and maintainability.

---

## 📂 Project Structure

```
UIAutomation/
│── Pages/             # Page Object Model (POM) classes
│── Tests/             # Test classes
│── Utils/             # Helper utilities (logging, config, etc.)
│── appsettings.json   # Configuration file
│── README.md          # Project documentation
```

---

## ⚙️ Prerequisites

- [Visual Studio 2022+](https://visualstudio.microsoft.com/)  
- [.NET 6 or later](https://dotnet.microsoft.com/)  
- [Google Chrome](https://www.google.com/chrome/) (or any target browser)  
- ChromeDriver 

---

## 📦 Dependencies

The project uses the following NuGet packages:

- `Selenium.WebDriver`
- `Selenium.Support`
- `MSTest.TestFramework`
- `MSTest.TestAdapter`
- `WebDriverManager` (for auto-managing drivers)

To install:
```sh
dotnet add package Selenium.WebDriver
dotnet add package Selenium.Support
dotnet add package MSTest.TestFramework
dotnet add package MSTest.TestAdapter
dotnet add package WebDriverManager
```

---

## ▶️ Running Tests

From Visual Studio:
- Open **Test Explorer**
- Run all or selected tests

From CLI:
```sh
dotnet test
```

With test filtering:
```sh
dotnet test --filter TestCategory=Smoke
```

---

## 📊 Test Reports

Under Reports folder you can find the Extent Report

---

## ✅ Best Practices

- Follow **Page Object Model (POM)**  
- Use `WebDriverWait` for synchronization  
- Keep test data/config in `appsettings.json`  
- Use `[TestCategory]` for grouping tests  

---

## 📖 References

- [Selenium WebDriver Documentation](https://www.selenium.dev/documentation/webdriver/)  
- [MSTest Documentation](https://learn.microsoft.com/en-us/dotnet/core/testing/unit-testing-with-mstest)  
- [WebDriverManager for .NET](https://github.com/rosolko/WebDriverManager.Net)  

---


