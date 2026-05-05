# Tahap Pengerjaan SIMANIK

## Ringkasan 6 Tahap

| Tahap | Fokus | PIC utama | Output |
| --- | --- | --- | --- |
| 1 | Struktur project, database, koneksi, model | Semua, koordinasi Anggota 1 | Folder `konfigurasi`, `model`, `service`, `view`, database `simanik`, class model |
| 2 | Login, registrasi, session, dashboard role | Anggota 1 | `login_fm`, `register_pasien_fm`, `Auth_serv`, `User_serv`, dashboard Admin/Dokter/Pasien |
| 3 | Master dokter, jadwal, penyakit | Anggota 2 | `Doctor_serv`, `Schedule_serv`, `Disease_serv`, form dokter/jadwal/penyakit |
| 4 | Pasien, reservasi, verifikasi, check-in, antrian | Anggota 3 | `Patient_serv`, `Reservation_serv`, `Visit_serv`, form pasien/reservasi/check-in/antrian |
| 5 | Pemeriksaan, obat, resep, rekam medis | Anggota 4 | `Examination_serv`, `Medicine_serv`, `Prescription_serv`, `MedicalRecord_serv` |
| 6 | Riwayat, laporan, integrasi, testing, demo | Semua | `Report_serv`, form riwayat/laporan, alur demo end-to-end |

## Pembagian 4 Orang

Anggota 1 pegang autentikasi, akun, session, dashboard, dan koordinasi struktur.

Anggota 2 pegang master data dokter, jadwal dokter, dan penyakit.

Anggota 3 pegang data pasien, reservasi, verifikasi, check-in, dan antrian.

Anggota 4 pegang pemeriksaan, obat, resep, rekam medis, riwayat, dan laporan.

## Urutan Integrasi

1. Import `Database/simanik.sql`, pastikan `konfigurasi/Koneksi.cs` mengarah ke database `simanik`.
2. Jalankan login dan dashboard dasar.
3. Selesaikan master data agar dropdown dokter, jadwal, penyakit, dan obat punya sumber data.
4. Integrasikan alur pasien reservasi sampai admin check-in.
5. Integrasikan alur dokter pemeriksaan sampai stok obat berkurang.
6. Rapikan validasi, pesan error, laporan, dan skenario demo.
