-- phpMyAdmin SQL Dump
-- version 5.2.1
-- https://www.phpmyadmin.net/
--
-- Host: 127.0.0.1
-- Waktu pembuatan: 05 Bulan Mei 2026 pada 05.25
-- Versi server: 10.4.32-MariaDB
-- Versi PHP: 8.2.12

SET SQL_MODE = "NO_AUTO_VALUE_ON_ZERO";
START TRANSACTION;
SET time_zone = "+07:00";


/*!40101 SET @OLD_CHARACTER_SET_CLIENT=@@CHARACTER_SET_CLIENT */;
/*!40101 SET @OLD_CHARACTER_SET_RESULTS=@@CHARACTER_SET_RESULTS */;
/*!40101 SET @OLD_COLLATION_CONNECTION=@@COLLATION_CONNECTION */;
/*!40101 SET NAMES utf8mb4 */;

--
-- Database: `simanik`
--

-- --------------------------------------------------------

--
-- Struktur dari tabel `detail_resep`
--

CREATE TABLE `detail_resep` (
  `id_detail` int(11) NOT NULL,
  `id_pemeriksaan` int(11) DEFAULT NULL,
  `id_obat` int(11) DEFAULT NULL,
  `jumlah` int(11) DEFAULT NULL,
  `catatan_aturan` varchar(255) DEFAULT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_general_ci;

--
-- Dumping data untuk tabel `detail_resep`
--

INSERT INTO `detail_resep` (`id_detail`, `id_pemeriksaan`, `id_obat`, `jumlah`, `catatan_aturan`) VALUES
(100, 100, 1, 5, '3x1 setelah makan'),
(101, 100, 3, 8, '2x1 setelah makan'),
(102, 101, 3, 5, '2x1 setelah makan');

-- --------------------------------------------------------

--
-- Struktur dari tabel `dokter`
--

CREATE TABLE `dokter` (
  `id_dokter` int(11) NOT NULL,
  `id_user` int(11) DEFAULT NULL,
  `nama_lengkap` varchar(100) DEFAULT NULL,
  `spesialisasi` varchar(100) DEFAULT NULL,
  `no_hp` varchar(20) DEFAULT NULL,
  `aktif` tinyint(1) DEFAULT 1
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_general_ci;

--
-- Dumping data untuk tabel `dokter`
--

INSERT INTO `dokter` (`id_dokter`, `id_user`, `nama_lengkap`, `spesialisasi`, `no_hp`, `aktif`) VALUES
(100, 100, 'dr. Budi Santoso', 'Dokter Umum', '081211110001', 1),
(101, 101, 'drg. Siti Rahma', 'Dokter Gigi', '081211110002', 1),
(102, 102, 'dr. Andi Wijaya, Sp.A', 'Dokter Anak', '081211110003', 1);

-- --------------------------------------------------------

--
-- Struktur dari tabel `jadwal_dokter`
--

CREATE TABLE `jadwal_dokter` (
  `id_jadwal` int(11) NOT NULL,
  `id_dokter` int(11) DEFAULT NULL,
  `tanggal` date DEFAULT NULL,
  `jam_mulai` time DEFAULT NULL,
  `jam_selesai` time DEFAULT NULL,
  `kuota` int(11) DEFAULT NULL,
  `aktif` tinyint(1) DEFAULT 1
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_general_ci;

--
-- Dumping data untuk tabel `jadwal_dokter`
--

INSERT INTO `jadwal_dokter` (`id_jadwal`, `id_dokter`, `tanggal`, `jam_mulai`, `jam_selesai`, `kuota`, `aktif`) VALUES
(100, 100, '2026-04-21', '08:00:00', '11:00:00', 12, 1),
(101, 101, '2026-04-21', '13:00:00', '15:00:00', 10, 1),
(102, 102, '2026-04-21', '16:00:00', '18:00:00', 8, 1);

-- --------------------------------------------------------

--
-- Struktur dari tabel `kunjungan`
--

CREATE TABLE `kunjungan` (
  `id_kunjungan` int(11) NOT NULL,
  `id_reservasi` int(11) DEFAULT NULL,
  `nomor_antrian` int(11) DEFAULT NULL,
  `waktu_checkin` datetime DEFAULT current_timestamp(),
  `status_kunjungan` enum('Menunggu','Sedang Diperiksa','Selesai') DEFAULT 'Menunggu'
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_general_ci;

--
-- Dumping data untuk tabel `kunjungan`
--

INSERT INTO `kunjungan` (`id_kunjungan`, `id_reservasi`, `nomor_antrian`, `waktu_checkin`, `status_kunjungan`) VALUES
(100, 100, 1, '2026-04-21 08:55:00', 'Selesai'),
(101, 101, 1, '2026-04-22 09:25:00', 'Menunggu');

-- --------------------------------------------------------

--
-- Struktur dari tabel `obat`
--

CREATE TABLE `obat` (
  `id_obat` int(11) NOT NULL,
  `nama_obat` varchar(100) DEFAULT NULL,
  `jenis_obat` varchar(50) DEFAULT NULL,
  `stok` int(11) DEFAULT 0,
  `satuan` varchar(30) DEFAULT NULL,
  `aturan_pakai_default` varchar(255) DEFAULT NULL,
  `aktif` tinyint(1) DEFAULT 1
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_general_ci;

--
-- Dumping data untuk tabel `obat`
--

INSERT INTO `obat` (`id_obat`, `nama_obat`, `jenis_obat`, `stok`, `satuan`, `aturan_pakai_default`, `aktif`) VALUES
(1, 'Paracetamol', 'Tablet', 100, 'tablet', '3x1 setelah makan', 1),
(2, 'Amoxicillin', 'Kapsul', 50, 'kapsul', '3x1 setelah makan', 1),
(3, 'OBH', 'Sirup', 30, 'botol', '3x1 sendok makan', 1),
(100, 'Cetirizine', 'Tablet', 80, 'tablet', '1x1 malam hari', 1),
(101, 'Ibuprofen', 'Tablet', 75, 'tablet', '2x1 setelah makan', 1);

-- --------------------------------------------------------

--
-- Struktur dari tabel `pasien`
--

CREATE TABLE `pasien` (
  `id_pasien` int(11) NOT NULL,
  `id_user` int(11) DEFAULT NULL,
  `no_rekam_medis` varchar(20) DEFAULT NULL,
  `nama_lengkap` varchar(100) DEFAULT NULL,
  `tanggal_lahir` date DEFAULT NULL,
  `jenis_kelamin` enum('Laki-laki','Perempuan') DEFAULT NULL,
  `alamat` varchar(255) DEFAULT NULL,
  `no_hp` varchar(20) DEFAULT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_general_ci;

--
-- Dumping data untuk tabel `pasien`
--

INSERT INTO `pasien` (`id_pasien`, `id_user`, `no_rekam_medis`, `nama_lengkap`, `tanggal_lahir`, `jenis_kelamin`, `alamat`, `no_hp`) VALUES
(100, 200, 'RM000100', 'Andi Saputra', '1998-01-12', 'Laki-laki', 'Jl. Melati No. 10', '081300000100'),
(101, 201, 'RM000101', 'Sari Wulandari', '2001-05-20', 'Perempuan', 'Jl. Kenanga No. 21', '081300000101');

-- --------------------------------------------------------

--
-- Struktur dari tabel `pemeriksaan`
--

CREATE TABLE `pemeriksaan` (
  `id_pemeriksaan` int(11) NOT NULL,
  `id_kunjungan` int(11) DEFAULT NULL,
  `id_dokter` int(11) DEFAULT NULL,
  `id_penyakit` int(11) DEFAULT NULL,
  `tanggal_periksa` datetime DEFAULT current_timestamp(),
  `keluhan_saat_ini` varchar(255) DEFAULT NULL,
  `catatan_diagnosa` varchar(255) DEFAULT NULL,
  `catatan_tindakan` varchar(255) DEFAULT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_general_ci;

--
-- Dumping data untuk tabel `pemeriksaan`
--

INSERT INTO `pemeriksaan` (`id_pemeriksaan`, `id_kunjungan`, `id_dokter`, `id_penyakit`, `tanggal_periksa`, `keluhan_saat_ini`, `catatan_diagnosa`, `catatan_tindakan`) VALUES
(100, 100, 100, 2, '2026-04-21 09:25:00', 'Demam dan sakit kepala', 'Diagnosa demam', 'Istirahat & obat'),
(101, 101, 101, 3, '2026-04-22 08:45:00', 'Batuk pilek', 'Diagnosa batuk', 'Obat batuk');

-- --------------------------------------------------------

--
-- Struktur dari tabel `penyakit`
--

CREATE TABLE `penyakit` (
  `id_penyakit` int(11) NOT NULL,
  `kode_penyakit` varchar(20) DEFAULT NULL,
  `nama_penyakit` varchar(100) DEFAULT NULL,
  `deskripsi` varchar(255) DEFAULT NULL,
  `aktif` tinyint(1) DEFAULT 1
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_general_ci;

--
-- Dumping data untuk tabel `penyakit`
--

INSERT INTO `penyakit` (`id_penyakit`, `kode_penyakit`, `nama_penyakit`, `deskripsi`, `aktif`) VALUES
(1, 'FLU', 'Influenza', 'Infeksi saluran pernapasan akibat virus', 1),
(2, 'DEM', 'Demam', 'Peningkatan suhu tubuh', 1),
(3, 'BAT', 'Batuk', 'Gejala gangguan saluran pernapasan', 1),
(4, 'HIP', 'Hipertensi', 'Tekanan darah tinggi', 1),
(5, 'DIA', 'Diabetes Mellitus', 'Gangguan kadar gula darah', 1);

-- --------------------------------------------------------

--
-- Struktur dari tabel `rekam_medis`
--

CREATE TABLE `rekam_medis` (
  `id_rekam` int(11) NOT NULL,
  `id_pasien` int(11) DEFAULT NULL,
  `terakhir_kunjungan` datetime DEFAULT NULL,
  `golongan_darah` varchar(5) DEFAULT NULL,
  `catatan_alergi` varchar(255) DEFAULT NULL,
  `catatan_penyakit_kronis` varchar(255) DEFAULT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_general_ci;

--
-- Dumping data untuk tabel `rekam_medis`
--

INSERT INTO `rekam_medis` (`id_rekam`, `id_pasien`, `terakhir_kunjungan`, `golongan_darah`, `catatan_alergi`, `catatan_penyakit_kronis`) VALUES
(100, 100, '2026-04-21 09:25:00', 'A', 'Tidak ada', 'Tidak ada'),
(101, 101, '2026-04-22 08:45:00', 'B', 'Debu', 'Asma ringan');

-- --------------------------------------------------------

--
-- Struktur dari tabel `reservasi`
--

CREATE TABLE `reservasi` (
  `id_reservasi` int(11) NOT NULL,
  `id_pasien` int(11) DEFAULT NULL,
  `id_jadwal` int(11) DEFAULT NULL,
  `keluhan` varchar(255) DEFAULT NULL,
  `status_reservasi` enum('Menunggu Verifikasi','Dikonfirmasi','Ditolak','Dibatalkan Pasien','Check-in','Selesai') DEFAULT 'Menunggu Verifikasi',
  `alasan_penolakan` varchar(255) DEFAULT NULL,
  `dibuat_pada` datetime DEFAULT current_timestamp()
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_general_ci;

--
-- Dumping data untuk tabel `reservasi`
--

INSERT INTO `reservasi` (`id_reservasi`, `id_pasien`, `id_jadwal`, `keluhan`, `status_reservasi`, `alasan_penolakan`, `dibuat_pada`) VALUES
(100, 100, 100, 'Demam dan sakit kepala sejak kemarin', 'Selesai', NULL, '2026-05-04 21:31:47'),
(101, 101, 101, 'Batuk pilek dan tenggorokan gatal', 'Menunggu Verifikasi', NULL, '2026-05-04 21:31:47');

-- --------------------------------------------------------

--
-- Struktur dari tabel `user`
--

CREATE TABLE `user` (
  `id_user` int(11) NOT NULL,
  `username` varchar(50) DEFAULT NULL,
  `password` varchar(255) DEFAULT NULL,
  `role` enum('Admin','Dokter','Pasien') DEFAULT NULL,
  `aktif` tinyint(1) DEFAULT 1,
  `dibuat_pada` datetime DEFAULT current_timestamp()
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_general_ci;

--
-- Dumping data untuk tabel `user`
--

INSERT INTO `user` (`id_user`, `username`, `password`, `role`, `aktif`, `dibuat_pada`) VALUES
(1, 'admin', 'admin123', 'Admin', 1, '2026-05-04 21:35:06'),
(100, 'dokter_umum', 'xxx', 'Dokter', 1, '2026-05-04 21:31:47'),
(101, 'dokter_gigi', 'xxx', 'Dokter', 1, '2026-05-04 21:31:47'),
(102, 'dokter_anak', 'xxx', 'Dokter', 1, '2026-05-04 21:31:47'),
(200, 'pasien_andi', 'xxx', 'Pasien', 1, '2026-05-04 21:31:47'),
(201, 'pasien_sari', 'xxx', 'Pasien', 1, '2026-05-04 21:31:47');

--
-- Indexes for dumped tables
--

--
-- Indeks untuk tabel `detail_resep`
--
ALTER TABLE `detail_resep`
  ADD PRIMARY KEY (`id_detail`),
  ADD KEY `id_pemeriksaan` (`id_pemeriksaan`),
  ADD KEY `id_obat` (`id_obat`);

--
-- Indeks untuk tabel `dokter`
--
ALTER TABLE `dokter`
  ADD PRIMARY KEY (`id_dokter`),
  ADD UNIQUE KEY `id_user` (`id_user`);

--
-- Indeks untuk tabel `jadwal_dokter`
--
ALTER TABLE `jadwal_dokter`
  ADD PRIMARY KEY (`id_jadwal`),
  ADD KEY `id_dokter` (`id_dokter`);

--
-- Indeks untuk tabel `kunjungan`
--
ALTER TABLE `kunjungan`
  ADD PRIMARY KEY (`id_kunjungan`),
  ADD UNIQUE KEY `id_reservasi` (`id_reservasi`);

--
-- Indeks untuk tabel `obat`
--
ALTER TABLE `obat`
  ADD PRIMARY KEY (`id_obat`);

--
-- Indeks untuk tabel `pasien`
--
ALTER TABLE `pasien`
  ADD PRIMARY KEY (`id_pasien`),
  ADD UNIQUE KEY `id_user` (`id_user`),
  ADD UNIQUE KEY `no_rekam_medis` (`no_rekam_medis`);

--
-- Indeks untuk tabel `pemeriksaan`
--
ALTER TABLE `pemeriksaan`
  ADD PRIMARY KEY (`id_pemeriksaan`),
  ADD UNIQUE KEY `id_kunjungan` (`id_kunjungan`),
  ADD KEY `id_dokter` (`id_dokter`),
  ADD KEY `id_penyakit` (`id_penyakit`);

--
-- Indeks untuk tabel `penyakit`
--
ALTER TABLE `penyakit`
  ADD PRIMARY KEY (`id_penyakit`),
  ADD UNIQUE KEY `kode_penyakit` (`kode_penyakit`);

--
-- Indeks untuk tabel `rekam_medis`
--
ALTER TABLE `rekam_medis`
  ADD PRIMARY KEY (`id_rekam`),
  ADD UNIQUE KEY `id_pasien` (`id_pasien`);

--
-- Indeks untuk tabel `reservasi`
--
ALTER TABLE `reservasi`
  ADD PRIMARY KEY (`id_reservasi`),
  ADD KEY `id_pasien` (`id_pasien`),
  ADD KEY `id_jadwal` (`id_jadwal`);

--
-- Indeks untuk tabel `user`
--
ALTER TABLE `user`
  ADD PRIMARY KEY (`id_user`),
  ADD UNIQUE KEY `username` (`username`);

--
-- AUTO_INCREMENT untuk tabel yang dibuang
--

--
-- AUTO_INCREMENT untuk tabel `detail_resep`
--
ALTER TABLE `detail_resep`
  MODIFY `id_detail` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=103;

--
-- AUTO_INCREMENT untuk tabel `dokter`
--
ALTER TABLE `dokter`
  MODIFY `id_dokter` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=103;

--
-- AUTO_INCREMENT untuk tabel `jadwal_dokter`
--
ALTER TABLE `jadwal_dokter`
  MODIFY `id_jadwal` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=103;

--
-- AUTO_INCREMENT untuk tabel `kunjungan`
--
ALTER TABLE `kunjungan`
  MODIFY `id_kunjungan` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=102;

--
-- AUTO_INCREMENT untuk tabel `obat`
--
ALTER TABLE `obat`
  MODIFY `id_obat` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=102;

--
-- AUTO_INCREMENT untuk tabel `pasien`
--
ALTER TABLE `pasien`
  MODIFY `id_pasien` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=102;

--
-- AUTO_INCREMENT untuk tabel `pemeriksaan`
--
ALTER TABLE `pemeriksaan`
  MODIFY `id_pemeriksaan` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=102;

--
-- AUTO_INCREMENT untuk tabel `penyakit`
--
ALTER TABLE `penyakit`
  MODIFY `id_penyakit` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=13;

--
-- AUTO_INCREMENT untuk tabel `rekam_medis`
--
ALTER TABLE `rekam_medis`
  MODIFY `id_rekam` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=102;

--
-- AUTO_INCREMENT untuk tabel `reservasi`
--
ALTER TABLE `reservasi`
  MODIFY `id_reservasi` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=102;

--
-- AUTO_INCREMENT untuk tabel `user`
--
ALTER TABLE `user`
  MODIFY `id_user` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=202;

--
-- Ketidakleluasaan untuk tabel pelimpahan (Dumped Tables)
--

--
-- Ketidakleluasaan untuk tabel `detail_resep`
--
ALTER TABLE `detail_resep`
  ADD CONSTRAINT `detail_resep_ibfk_1` FOREIGN KEY (`id_pemeriksaan`) REFERENCES `pemeriksaan` (`id_pemeriksaan`),
  ADD CONSTRAINT `detail_resep_ibfk_2` FOREIGN KEY (`id_obat`) REFERENCES `obat` (`id_obat`);

--
-- Ketidakleluasaan untuk tabel `dokter`
--
ALTER TABLE `dokter`
  ADD CONSTRAINT `dokter_ibfk_1` FOREIGN KEY (`id_user`) REFERENCES `user` (`id_user`);

--
-- Ketidakleluasaan untuk tabel `jadwal_dokter`
--
ALTER TABLE `jadwal_dokter`
  ADD CONSTRAINT `jadwal_dokter_ibfk_1` FOREIGN KEY (`id_dokter`) REFERENCES `dokter` (`id_dokter`);

--
-- Ketidakleluasaan untuk tabel `kunjungan`
--
ALTER TABLE `kunjungan`
  ADD CONSTRAINT `kunjungan_ibfk_1` FOREIGN KEY (`id_reservasi`) REFERENCES `reservasi` (`id_reservasi`);

--
-- Ketidakleluasaan untuk tabel `pasien`
--
ALTER TABLE `pasien`
  ADD CONSTRAINT `pasien_ibfk_1` FOREIGN KEY (`id_user`) REFERENCES `user` (`id_user`);

--
-- Ketidakleluasaan untuk tabel `pemeriksaan`
--
ALTER TABLE `pemeriksaan`
  ADD CONSTRAINT `pemeriksaan_ibfk_1` FOREIGN KEY (`id_kunjungan`) REFERENCES `kunjungan` (`id_kunjungan`),
  ADD CONSTRAINT `pemeriksaan_ibfk_2` FOREIGN KEY (`id_dokter`) REFERENCES `dokter` (`id_dokter`),
  ADD CONSTRAINT `pemeriksaan_ibfk_3` FOREIGN KEY (`id_penyakit`) REFERENCES `penyakit` (`id_penyakit`);

--
-- Ketidakleluasaan untuk tabel `rekam_medis`
--
ALTER TABLE `rekam_medis`
  ADD CONSTRAINT `rekam_medis_ibfk_1` FOREIGN KEY (`id_pasien`) REFERENCES `pasien` (`id_pasien`);

--
-- Ketidakleluasaan untuk tabel `reservasi`
--
ALTER TABLE `reservasi`
  ADD CONSTRAINT `reservasi_ibfk_1` FOREIGN KEY (`id_pasien`) REFERENCES `pasien` (`id_pasien`),
  ADD CONSTRAINT `reservasi_ibfk_2` FOREIGN KEY (`id_jadwal`) REFERENCES `jadwal_dokter` (`id_jadwal`);
COMMIT;

/*!40101 SET CHARACTER_SET_CLIENT=@OLD_CHARACTER_SET_CLIENT */;
/*!40101 SET CHARACTER_SET_RESULTS=@OLD_CHARACTER_SET_RESULTS */;
/*!40101 SET COLLATION_CONNECTION=@OLD_COLLATION_CONNECTION */;
