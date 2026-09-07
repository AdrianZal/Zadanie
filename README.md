# Zadanie Rekrutacyjne - Cat Facts Fetcher

**Opis projektu**
Aplikacja w .NET 9 realizująca zadanie rekrutacyjne. Łączy się z endpointem `https://catfact.ninja/fact`, pobiera dane i dopisuje otrzymany fakt o kotach jako nowy wiersz do lokalnego pliku `.txt`.

**Zrealizowane funkcjonalności**
* Wykorzystanie technologii Microsoft (.NET 9.0).
* Asynchroniczne połączenie z zewnętrznym API.
* Operacje na plikach - lokalne tworzenie i dopisywanie danych do pliku tekstowego.
* Zastosowanie wstrzykiwania zależności (Dependency Injection).
* Weryfikacja działania serwisów za pomocą testów jednostkowych (xUnit, Moq).

**Struktura rozwiązania**
* `ZadanieRekrutacyjne` - główny kod aplikacji z logiką serwisów (`CatFactService`, `FileService`).
* `Zadanierekrutacyjne.Tests` - projekt z testami jednostkowymi.

**Uruchomienie**
1. Sklonuj repozytorium.
2. Aby uruchomić aplikację, przejdź do katalogu głównego i wykonaj:
   `dotnet run --project ZadanieRekrutacyjne`
3. Aby sprawdzić testy jednostkowe:
   `dotnet test`
