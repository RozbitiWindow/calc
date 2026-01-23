# 🧮 Calc

Konzolová kalkulačka v C# s podporou základních matematických operací.

## 📋 Popis

Calc je jednoduchá konzolová aplikace napsaná v C#, která umožňuje provádět základní matematické operace jako sčítání, odčítání, násobení a dělení.

## ✨ Funkce

- ➕ Sčítání
- ➖ Odčítání
- ✖️ Násobení
- ➗ Dělení
- 🎨 Barevný výstup (úspěch, chyby, varování)
- ✅ Validace vstupů
- 🔄 Opakované použití bez restartování

## 🏗️ Struktura projektu
```
Calc/
├── Program.cs         # Hlavní vstupní bod
├── OutputWriter.cs    # Třída pro formátovaný výpis
├── InputReader.cs     # Třída pro čtení vstupu (pokud existuje)
└── Calculator.cs      # Logika kalkulačky (pokud existuje)
```

## 🔧 Technologie

- **Jazyk:** C#
- **Framework:** .NET
- **Typ aplikace:** Console Application

## 📐 Design principy

Projekt dodržuje:
- **Single Responsibility Principle** - oddělení logiky od prezentace
- **PascalCase** pro názvy tříd a metod
- Čistý a čitelný kód
- Oddělené třídy pro různé odpovědnosti

## 🚀 Jak spustit
```bash
# Naklonuj repozitář
git clone https://github.com/RozbitiWindow/Calc.git

# Přejdi do složky
cd Calc

# Spusť aplikaci
dotnet run
```

## 💡 Použití
```
Vítej v kalkulačce!
Vyber operaci:
1. Sčítání
2. Odčítání
3. Násobení
4. Dělení
5. Konec

Zadej první číslo: 10
Zadej druhé číslo: 5
Výsledek: 15
```

## 🛡️ Ošetření chyb

- ✅ Validace numerických vstupů
- ✅ Ochrana proti dělení nulou
- ✅ Barevné zobrazení chybových hlášek
