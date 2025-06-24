# 🎲 Russian Roulette Console Game (C#)

Sebuah game konsol sederhana berbasis C# yang mensimulasikan permainan **Russian Roulette**. Game ini menampilkan dua pemain yang secara bergiliran menarik pelatuk pada revolver dengan peluru yang telah diacak. Siapa yang kena peluru, kalah!


## 🔧 Fitur Utama

- 🔁 Peluru diacak setiap kali silinder habis
- 🎯 Pemain dapat memilih jumlah peluru (1–5)
- 📊 Persentase peluang tertembak ditampilkan sebelum permainan
- 🧠 Urutan pemain ditentukan secara acak setiap game
- 🎮 Bisa dimainkan berkali-kali (looped gameplay)


## 🚀 Cara Menjalankan

1. **Clone repositori ini** (atau download ZIP):
   ```bash
   git clone https://github.com/username/russian-roulette-csharp.git
   ```
2. **Pindah ke direktori projek**
   ```bash
   cd russian-roulette-csharp
   ```
3. **Jalankan script program**
   ```bash
   dotnet run
   ```


## 🎮 Cara Bermain

1. Di awal permainan, kamu akan diminta untuk menentukan jumlah peluru.
2. Persentase peluang tertembak akan ditampilkan.
3. Dua pemain akan bermain bergiliran.
4. Jika peluru ditembakkan, pemain tersebut kalah.
5. Jika semua chamber sudah digunakan tanpa ada yang tertembak, silinder akan diacak ulang secara otomatis.


## 📷 Contoh Gameplay

```bash
💡 Enter number of bullets (1-5): 2
🎯 Chance of getting shot per turn: 33.3%

🔄 Random start! Player Two goes first.

Player Two's turn, press Enter to pull the trigger...
😮 Player Two got blank. You're lucky!

Player One's turn, press Enter to pull the trigger...
💥 BOOM! Player One got shot.
💀 Game over.

🔁 Do you want to play again? (yes/no): no
👋 Thanks for playing!
```
