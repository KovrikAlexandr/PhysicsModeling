Для запуска программы требуется установить dotnet8.0 и собрать проект консольной командой `dotnet run`
---
Сначала программа переводит координаты из введённой системы в декартову, затем из декартовой в остальные.

## Использованные формулы

### Декартовы в сферические:

- r = sqrt(x² + y² + z²)
- θ = arccos(z / r)
- φ = atan2(y, x)

### Декартовы в цилиндрические:

- ρ = sqrt(x² + y²)
- φ = atan2(y, x)
- z = z

### Сферические в декартовы:

- x = r * sin(θ) * cos(φ)
- y = r * sin(θ) * sin(φ)
- z = r * cos(θ)

### Цилиндрические в декартовы:

- x = ρ * cos(φ)
- y = ρ * sin(φ)
- z = z