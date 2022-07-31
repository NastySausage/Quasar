﻿using System.Security.Cryptography.X509Certificates;

namespace Quasar.Server
{
    /// <summary>
    /// Provides a dummy certificate for debugging. Do not use in production.
    /// </summary>
    public sealed class DummyCertificate : X509Certificate2
    {
        private static readonly byte[] CertificateBytes =
        {
            48, 130, 16, 163, 2, 1, 3, 48, 130, 16, 95, 6, 9, 42, 134, 72, 134, 247, 13, 1, 7, 1, 160, 130, 16, 80, 4,
            130, 16, 76, 48, 130, 16, 72, 48, 130, 10, 177, 6, 9, 42, 134, 72, 134, 247, 13, 1, 7, 1, 160, 130, 10, 162,
            4, 130, 10, 158, 48, 130, 10, 154, 48, 130, 10, 150, 6, 11, 42, 134, 72, 134, 247, 13, 1, 12, 10, 1, 2, 160,
            130, 9, 126, 48, 130, 9, 122, 48, 28, 6, 10, 42, 134, 72, 134, 247, 13, 1, 12, 1, 3, 48, 14, 4, 8, 55, 218,
            160, 56, 14, 249, 193, 233, 2, 2, 7, 208, 4, 130, 9, 88, 200, 194, 253, 138, 219, 236, 70, 232, 138, 10, 70,
            100, 167, 76, 74, 50, 45, 18, 111, 58, 93, 132, 87, 28, 203, 147, 242, 255, 250, 211, 45, 70, 61, 227, 211,
            189, 24, 140, 30, 238, 231, 207, 40, 100, 115, 10, 78, 79, 243, 48, 109, 55, 71, 46, 223, 169, 135, 33, 119,
            67, 58, 16, 65, 45, 3, 94, 57, 129, 84, 18, 83, 77, 105, 100, 87, 180, 125, 168, 229, 247, 113, 150, 224,
            249, 36, 150, 140, 88, 20, 195, 200, 125, 3, 161, 133, 194, 135, 71, 196, 59, 7, 101, 146, 63, 140, 0, 0,
            190, 166, 13, 86, 157, 225, 181, 78, 176, 62, 206, 73, 30, 69, 99, 65, 197, 122, 75, 135, 21, 122, 19, 110,
            25, 0, 19, 130, 90, 74, 32, 117, 253, 141, 107, 149, 94, 122, 121, 251, 129, 17, 152, 23, 148, 19, 81, 178,
            237, 190, 85, 253, 215, 145, 119, 77, 0, 69, 76, 148, 226, 232, 121, 200, 51, 213, 142, 55, 68, 238, 132,
            80, 196, 163, 175, 246, 6, 205, 164, 59, 159, 111, 72, 42, 100, 8, 37, 152, 69, 241, 237, 217, 20, 168, 30,
            168, 54, 131, 47, 127, 229, 13, 24, 33, 109, 37, 254, 105, 168, 48, 81, 20, 166, 150, 43, 242, 139, 104,
            209, 134, 51, 8, 6, 255, 107, 49, 40, 140, 41, 130, 238, 6, 193, 51, 203, 107, 144, 43, 60, 118, 9, 243, 96,
            45, 212, 72, 129, 126, 204, 180, 165, 208, 158, 174, 244, 42, 241, 148, 107, 231, 233, 80, 117, 114, 204,
            37, 80, 246, 180, 99, 138, 254, 132, 96, 235, 171, 136, 82, 198, 55, 115, 203, 195, 180, 150, 155, 182, 73,
            191, 146, 194, 83, 98, 114, 100, 93, 146, 25, 36, 71, 169, 179, 22, 119, 49, 38, 60, 147, 27, 32, 168, 45,
            140, 6, 83, 44, 14, 226, 54, 122, 98, 105, 50, 191, 166, 12, 102, 226, 110, 220, 54, 42, 141, 93, 11, 200,
            172, 94, 19, 75, 164, 69, 17, 145, 108, 138, 54, 226, 47, 226, 2, 6, 209, 217, 27, 136, 7, 189, 189, 20, 60,
            77, 186, 166, 233, 243, 15, 2, 62, 82, 219, 35, 144, 191, 26, 21, 20, 200, 92, 70, 215, 127, 243, 180, 125,
            222, 249, 91, 125, 54, 117, 123, 0, 86, 65, 156, 222, 235, 164, 184, 54, 117, 24, 176, 198, 242, 144, 109,
            212, 0, 195, 16, 219, 74, 28, 101, 99, 107, 102, 202, 58, 247, 59, 220, 218, 57, 245, 103, 90, 85, 252, 205,
            105, 125, 109, 154, 142, 77, 76, 146, 49, 222, 17, 149, 128, 106, 106, 231, 75, 106, 4, 127, 146, 15, 143,
            40, 136, 178, 225, 61, 123, 70, 135, 188, 34, 235, 63, 89, 77, 154, 55, 65, 194, 36, 70, 61, 176, 80, 33,
            69, 224, 131, 147, 75, 240, 179, 195, 45, 226, 152, 9, 142, 95, 30, 108, 203, 1, 179, 113, 138, 86, 3, 155,
            17, 171, 178, 179, 200, 172, 189, 230, 211, 167, 111, 219, 157, 175, 110, 33, 53, 162, 249, 155, 110, 249,
            159, 120, 168, 146, 98, 119, 140, 238, 13, 77, 16, 35, 183, 200, 20, 74, 25, 105, 245, 48, 91, 75, 210, 195,
            168, 76, 172, 157, 202, 203, 108, 34, 162, 141, 136, 183, 111, 195, 40, 142, 151, 95, 157, 57, 211, 5, 127,
            199, 170, 45, 192, 147, 52, 17, 75, 197, 52, 214, 172, 126, 206, 134, 135, 204, 128, 251, 33, 36, 238, 83,
            74, 59, 166, 161, 177, 59, 226, 243, 152, 190, 168, 212, 127, 120, 115, 65, 76, 132, 115, 150, 146, 225,
            210, 208, 114, 121, 11, 107, 230, 225, 140, 250, 169, 215, 83, 231, 124, 35, 207, 76, 20, 69, 31, 184, 210,
            184, 55, 170, 226, 118, 0, 252, 105, 91, 201, 82, 36, 4, 45, 135, 38, 168, 81, 202, 91, 49, 217, 213, 26,
            210, 77, 37, 5, 57, 71, 227, 23, 58, 18, 221, 194, 34, 88, 218, 219, 124, 48, 230, 8, 239, 185, 169, 150,
            190, 246, 112, 92, 208, 93, 160, 248, 197, 64, 196, 20, 20, 11, 239, 147, 195, 179, 47, 136, 153, 24, 143,
            103, 57, 88, 246, 122, 63, 203, 165, 192, 130, 130, 228, 235, 45, 36, 103, 235, 165, 72, 130, 45, 222, 212,
            50, 179, 154, 77, 71, 102, 1, 44, 21, 19, 215, 240, 134, 231, 124, 222, 168, 210, 191, 141, 7, 193, 102,
            148, 81, 46, 6, 111, 14, 14, 48, 29, 21, 54, 166, 217, 32, 106, 240, 69, 137, 171, 58, 217, 110, 79, 172,
            92, 198, 174, 177, 196, 10, 10, 214, 105, 43, 125, 185, 217, 58, 252, 60, 229, 252, 126, 109, 79, 234, 35,
            215, 121, 141, 120, 21, 222, 174, 186, 64, 190, 244, 66, 251, 17, 168, 85, 199, 233, 182, 233, 75, 107, 0,
            176, 71, 27, 167, 216, 84, 78, 115, 128, 177, 20, 104, 248, 219, 68, 95, 250, 30, 126, 25, 223, 195, 17, 76,
            245, 157, 52, 91, 201, 180, 142, 110, 114, 229, 89, 65, 43, 72, 2, 44, 85, 207, 69, 15, 189, 152, 230, 94,
            245, 153, 171, 151, 15, 38, 177, 167, 28, 206, 43, 190, 125, 8, 106, 233, 168, 156, 106, 196, 116, 163, 130,
            10, 247, 189, 5, 181, 50, 254, 76, 158, 252, 132, 192, 117, 97, 158, 141, 33, 184, 27, 118, 101, 224, 128,
            59, 18, 247, 205, 18, 129, 45, 115, 122, 139, 11, 35, 18, 227, 210, 131, 181, 24, 41, 10, 177, 203, 116,
            241, 106, 117, 133, 217, 104, 173, 161, 44, 114, 98, 234, 7, 165, 200, 89, 183, 148, 230, 84, 129, 196, 142,
            146, 208, 121, 38, 64, 124, 23, 23, 181, 182, 54, 122, 142, 127, 204, 56, 30, 92, 113, 123, 182, 97, 186,
            214, 44, 237, 20, 141, 47, 38, 47, 197, 69, 237, 13, 5, 244, 220, 251, 31, 45, 223, 195, 193, 42, 136, 36,
            150, 133, 161, 244, 29, 82, 228, 253, 63, 147, 254, 58, 92, 194, 4, 162, 190, 16, 61, 177, 222, 122, 10, 73,
            106, 196, 243, 153, 240, 22, 223, 123, 107, 193, 59, 23, 45, 129, 14, 12, 184, 85, 22, 233, 165, 212, 188,
            30, 68, 154, 206, 135, 223, 170, 149, 242, 10, 55, 73, 215, 162, 5, 53, 75, 45, 179, 62, 160, 240, 145, 200,
            154, 61, 75, 135, 108, 33, 16, 206, 89, 185, 120, 182, 229, 224, 31, 98, 244, 136, 229, 55, 205, 55, 75,
            237, 41, 122, 64, 160, 189, 1, 15, 245, 126, 248, 74, 130, 135, 237, 66, 207, 142, 192, 217, 123, 74, 140,
            44, 93, 199, 145, 157, 103, 12, 235, 224, 194, 168, 213, 49, 82, 251, 182, 219, 240, 37, 197, 255, 120, 151,
            99, 204, 210, 191, 231, 8, 230, 241, 3, 136, 120, 234, 38, 251, 234, 130, 231, 30, 6, 123, 12, 147, 83, 195,
            107, 233, 97, 131, 124, 237, 7, 119, 16, 61, 243, 36, 24, 53, 8, 140, 85, 158, 232, 206, 234, 21, 163, 245,
            160, 171, 174, 130, 206, 74, 19, 178, 161, 187, 9, 69, 121, 179, 67, 24, 139, 165, 161, 189, 246, 203, 36,
            215, 192, 64, 32, 34, 201, 135, 179, 135, 111, 148, 202, 214, 11, 125, 200, 194, 8, 254, 86, 31, 134, 127,
            118, 217, 108, 94, 58, 158, 238, 164, 51, 65, 142, 247, 19, 244, 154, 56, 17, 159, 173, 138, 182, 220, 118,
            239, 73, 245, 229, 183, 44, 206, 238, 154, 153, 111, 97, 130, 52, 150, 241, 191, 20, 5, 237, 122, 12, 74,
            23, 154, 29, 229, 255, 210, 254, 180, 215, 111, 62, 254, 8, 69, 226, 216, 142, 183, 6, 114, 37, 178, 215,
            191, 166, 72, 34, 86, 77, 154, 110, 211, 90, 14, 233, 200, 43, 232, 193, 206, 26, 38, 76, 111, 187, 90, 118,
            142, 122, 92, 96, 124, 187, 144, 0, 164, 134, 211, 88, 60, 17, 169, 76, 105, 77, 243, 27, 155, 93, 33, 13,
            3, 184, 184, 220, 19, 174, 221, 225, 121, 112, 99, 122, 173, 96, 14, 98, 244, 42, 187, 57, 108, 8, 214, 60,
            77, 113, 249, 110, 152, 96, 52, 186, 176, 201, 142, 21, 204, 41, 163, 3, 192, 99, 140, 189, 152, 13, 65,
            222, 220, 49, 45, 202, 210, 249, 122, 135, 178, 19, 49, 16, 149, 203, 203, 62, 131, 91, 17, 171, 164, 149,
            34, 226, 96, 123, 32, 141, 102, 158, 186, 241, 59, 192, 186, 36, 41, 133, 115, 108, 121, 34, 104, 57, 141,
            167, 160, 58, 95, 171, 215, 122, 153, 129, 166, 10, 190, 60, 51, 70, 157, 141, 11, 104, 255, 111, 160, 173,
            174, 77, 83, 63, 130, 219, 36, 90, 254, 34, 55, 195, 216, 112, 194, 15, 126, 149, 143, 145, 175, 72, 24,
            120, 140, 217, 215, 27, 107, 240, 196, 196, 234, 81, 154, 152, 12, 44, 108, 173, 210, 32, 181, 172, 148, 75,
            71, 89, 136, 224, 28, 229, 121, 76, 64, 60, 200, 60, 200, 88, 193, 217, 252, 162, 181, 215, 99, 86, 47, 181,
            16, 49, 65, 158, 78, 130, 204, 188, 196, 25, 224, 201, 106, 237, 103, 183, 96, 58, 64, 185, 28, 66, 178,
            213, 47, 103, 26, 89, 33, 97, 248, 34, 232, 27, 30, 93, 57, 1, 236, 105, 46, 59, 4, 188, 47, 182, 150, 65,
            195, 107, 203, 52, 149, 240, 16, 130, 254, 189, 98, 56, 221, 177, 163, 66, 62, 123, 0, 252, 169, 178, 166,
            68, 167, 75, 64, 161, 80, 85, 196, 98, 209, 248, 46, 115, 188, 0, 160, 123, 147, 79, 151, 188, 206, 158,
            145, 42, 212, 205, 37, 163, 76, 221, 146, 51, 229, 181, 127, 53, 157, 142, 107, 215, 231, 181, 32, 110, 2,
            13, 55, 122, 56, 226, 158, 126, 124, 193, 193, 172, 222, 9, 211, 83, 166, 69, 95, 145, 169, 31, 211, 139,
            62, 215, 90, 226, 244, 129, 197, 143, 228, 185, 206, 236, 90, 218, 189, 234, 69, 57, 25, 49, 152, 175, 211,
            136, 202, 160, 116, 56, 118, 27, 204, 213, 3, 163, 97, 194, 156, 213, 7, 9, 254, 203, 230, 252, 173, 231,
            197, 135, 224, 3, 206, 157, 166, 193, 184, 153, 57, 253, 229, 87, 234, 118, 50, 163, 151, 53, 82, 206, 36,
            206, 128, 41, 180, 11, 30, 110, 49, 216, 236, 201, 46, 88, 157, 92, 221, 106, 88, 82, 198, 33, 91, 171, 117,
            88, 146, 58, 2, 30, 233, 215, 105, 141, 228, 183, 124, 244, 231, 224, 165, 131, 9, 33, 230, 211, 56, 215,
            221, 38, 141, 158, 48, 250, 119, 102, 226, 206, 32, 70, 140, 53, 210, 12, 206, 88, 220, 35, 2, 195, 157, 7,
            9, 215, 158, 85, 149, 89, 101, 46, 3, 253, 195, 82, 2, 12, 19, 149, 52, 209, 8, 242, 145, 34, 109, 185, 236,
            18, 2, 109, 96, 251, 3, 169, 68, 185, 63, 6, 213, 239, 100, 248, 111, 131, 243, 252, 214, 16, 140, 38, 159,
            138, 17, 141, 98, 96, 137, 140, 243, 11, 120, 69, 229, 212, 71, 2, 254, 98, 171, 207, 69, 72, 70, 186, 83,
            193, 208, 174, 125, 197, 148, 69, 35, 147, 134, 156, 106, 41, 72, 111, 140, 65, 185, 110, 212, 225, 34, 198,
            198, 47, 142, 160, 78, 217, 170, 7, 114, 50, 164, 217, 15, 37, 186, 211, 124, 75, 133, 64, 165, 120, 246,
            22, 226, 204, 186, 137, 154, 130, 142, 238, 147, 188, 206, 129, 19, 177, 117, 166, 180, 211, 16, 221, 29,
            112, 161, 109, 137, 224, 173, 205, 53, 158, 63, 198, 250, 131, 145, 118, 119, 12, 157, 94, 232, 27, 60, 254,
            57, 223, 154, 185, 96, 127, 137, 166, 238, 1, 58, 153, 154, 188, 9, 89, 20, 102, 191, 2, 106, 31, 27, 11,
            221, 206, 26, 145, 142, 192, 196, 28, 230, 213, 149, 52, 63, 48, 137, 25, 254, 27, 205, 207, 20, 5, 12, 37,
            34, 98, 188, 70, 50, 181, 187, 224, 166, 251, 59, 47, 226, 11, 130, 158, 52, 28, 70, 162, 165, 49, 111, 198,
            39, 64, 90, 213, 7, 91, 38, 95, 126, 160, 222, 205, 89, 27, 39, 1, 148, 126, 204, 179, 207, 235, 184, 7, 74,
            37, 64, 189, 167, 234, 196, 149, 160, 24, 111, 152, 246, 17, 184, 83, 189, 158, 106, 78, 221, 108, 87, 128,
            113, 112, 207, 53, 93, 48, 65, 128, 64, 194, 141, 126, 185, 130, 190, 66, 1, 20, 245, 213, 137, 66, 119, 18,
            225, 24, 225, 193, 179, 76, 132, 207, 169, 66, 221, 180, 135, 80, 17, 52, 243, 129, 80, 64, 151, 14, 65,
            233, 83, 72, 49, 251, 59, 67, 92, 87, 110, 34, 77, 14, 168, 126, 236, 155, 238, 213, 60, 233, 173, 83, 150,
            105, 241, 255, 97, 54, 48, 32, 93, 52, 30, 25, 227, 37, 151, 191, 46, 59, 19, 19, 225, 68, 161, 179, 19,
            144, 207, 67, 230, 67, 45, 197, 4, 162, 215, 43, 80, 96, 124, 130, 246, 27, 164, 94, 174, 205, 98, 102, 83,
            173, 247, 21, 11, 250, 32, 119, 29, 77, 42, 190, 97, 134, 48, 219, 57, 50, 52, 55, 184, 242, 109, 136, 100,
            214, 224, 129, 197, 233, 130, 119, 0, 242, 203, 131, 124, 175, 210, 225, 56, 53, 238, 177, 236, 77, 173, 82,
            83, 223, 217, 232, 149, 146, 184, 166, 40, 126, 134, 34, 50, 204, 75, 120, 124, 62, 139, 166, 244, 2, 38,
            172, 55, 41, 38, 206, 160, 17, 30, 163, 160, 110, 81, 182, 56, 1, 225, 252, 100, 24, 24, 231, 188, 239, 106,
            162, 108, 87, 120, 51, 80, 96, 184, 252, 121, 238, 164, 197, 30, 205, 52, 54, 95, 27, 96, 227, 161, 87, 127,
            98, 255, 5, 10, 92, 76, 93, 110, 237, 22, 176, 152, 10, 145, 194, 233, 38, 148, 237, 233, 134, 202, 52, 239,
            169, 47, 243, 189, 103, 232, 142, 146, 215, 49, 130, 1, 3, 48, 19, 6, 9, 42, 134, 72, 134, 247, 13, 1, 9,
            21, 49, 6, 4, 4, 1, 0, 0, 0, 48, 113, 6, 9, 42, 134, 72, 134, 247, 13, 1, 9, 20, 49, 100, 30, 98, 0, 66, 0,
            111, 0, 117, 0, 110, 0, 99, 0, 121, 0, 67, 0, 97, 0, 115, 0, 116, 0, 108, 0, 101, 0, 45, 0, 97, 0, 48, 0,
            48, 0, 101, 0, 98, 0, 48, 0, 102, 0, 54, 0, 45, 0, 98, 0, 50, 0, 99, 0, 54, 0, 45, 0, 52, 0, 51, 0, 57, 0,
            57, 0, 45, 0, 98, 0, 56, 0, 52, 0, 52, 0, 45, 0, 52, 0, 102, 0, 55, 0, 98, 0, 56, 0, 97, 0, 53, 0, 99, 0,
            99, 0, 97, 0, 51, 0, 101, 48, 121, 6, 9, 43, 6, 1, 4, 1, 130, 55, 17, 1, 49, 108, 30, 106, 0, 77, 0, 105, 0,
            99, 0, 114, 0, 111, 0, 115, 0, 111, 0, 102, 0, 116, 0, 32, 0, 69, 0, 110, 0, 104, 0, 97, 0, 110, 0, 99, 0,
            101, 0, 100, 0, 32, 0, 82, 0, 83, 0, 65, 0, 32, 0, 97, 0, 110, 0, 100, 0, 32, 0, 65, 0, 69, 0, 83, 0, 32, 0,
            67, 0, 114, 0, 121, 0, 112, 0, 116, 0, 111, 0, 103, 0, 114, 0, 97, 0, 112, 0, 104, 0, 105, 0, 99, 0, 32, 0,
            80, 0, 114, 0, 111, 0, 118, 0, 105, 0, 100, 0, 101, 0, 114, 48, 130, 5, 143, 6, 9, 42, 134, 72, 134, 247,
            13, 1, 7, 6, 160, 130, 5, 128, 48, 130, 5, 124, 2, 1, 0, 48, 130, 5, 117, 6, 9, 42, 134, 72, 134, 247, 13,
            1, 7, 1, 48, 28, 6, 10, 42, 134, 72, 134, 247, 13, 1, 12, 1, 3, 48, 14, 4, 8, 197, 180, 184, 234, 62, 183,
            126, 192, 2, 2, 7, 208, 128, 130, 5, 72, 82, 253, 63, 238, 110, 242, 96, 184, 169, 64, 162, 143, 164, 116,
            242, 201, 183, 48, 112, 176, 72, 130, 247, 187, 199, 107, 16, 243, 59, 238, 135, 24, 177, 105, 228, 132, 35,
            235, 193, 103, 217, 193, 235, 32, 106, 47, 90, 187, 129, 92, 191, 73, 144, 37, 5, 197, 190, 39, 243, 83, 21,
            161, 49, 59, 4, 20, 196, 238, 174, 98, 66, 242, 28, 1, 64, 47, 11, 244, 179, 45, 233, 11, 14, 243, 228, 32,
            116, 163, 144, 99, 153, 3, 60, 140, 225, 179, 5, 36, 120, 230, 202, 163, 174, 255, 75, 237, 233, 47, 60,
            199, 128, 161, 221, 232, 62, 29, 141, 232, 203, 237, 235, 192, 63, 11, 131, 67, 115, 141, 127, 14, 162, 124,
            17, 103, 207, 77, 158, 149, 108, 91, 67, 135, 123, 167, 133, 118, 22, 129, 57, 232, 95, 163, 123, 170, 191,
            180, 46, 205, 125, 163, 109, 20, 74, 227, 189, 68, 215, 146, 212, 38, 127, 73, 195, 207, 222, 227, 134, 145,
            6, 21, 223, 217, 237, 134, 129, 140, 153, 182, 143, 250, 219, 162, 254, 157, 18, 16, 141, 176, 249, 165,
            118, 85, 98, 35, 139, 214, 165, 27, 23, 63, 182, 201, 104, 202, 124, 81, 213, 194, 8, 108, 81, 126, 142,
            221, 175, 122, 165, 16, 153, 170, 31, 178, 122, 86, 73, 133, 136, 34, 177, 129, 90, 72, 24, 251, 91, 246,
            76, 186, 195, 122, 227, 93, 26, 71, 137, 201, 99, 222, 196, 156, 62, 195, 88, 46, 29, 254, 83, 23, 41, 143,
            103, 111, 79, 206, 5, 207, 10, 168, 23, 18, 197, 245, 24, 70, 154, 226, 196, 70, 147, 119, 217, 198, 196,
            171, 33, 121, 64, 180, 51, 50, 85, 57, 93, 179, 240, 248, 233, 139, 7, 191, 75, 193, 123, 119, 42, 239, 228,
            95, 145, 90, 67, 178, 119, 229, 71, 139, 57, 188, 152, 152, 153, 155, 1, 94, 238, 174, 215, 145, 56, 255,
            190, 101, 2, 136, 71, 228, 28, 7, 0, 166, 10, 122, 152, 40, 39, 125, 97, 206, 39, 41, 119, 61, 87, 14, 234,
            251, 29, 109, 14, 132, 20, 234, 182, 228, 218, 39, 4, 5, 118, 22, 37, 249, 138, 243, 253, 137, 27, 151, 87,
            27, 37, 77, 149, 96, 152, 24, 56, 1, 64, 231, 162, 137, 243, 105, 255, 97, 35, 41, 12, 25, 197, 79, 167, 79,
            187, 73, 229, 148, 253, 203, 46, 186, 201, 126, 225, 0, 218, 151, 176, 14, 243, 43, 178, 128, 153, 47, 182,
            215, 45, 3, 39, 191, 73, 215, 148, 26, 15, 98, 88, 41, 241, 160, 143, 77, 208, 218, 204, 113, 105, 169, 170,
            181, 93, 137, 112, 248, 17, 158, 240, 115, 117, 9, 220, 50, 103, 126, 151, 227, 146, 168, 132, 214, 100,
            167, 30, 113, 117, 163, 174, 177, 1, 88, 191, 53, 218, 213, 48, 39, 62, 179, 88, 37, 212, 69, 173, 199, 226,
            152, 80, 175, 165, 79, 67, 212, 249, 70, 109, 3, 160, 46, 253, 197, 14, 75, 79, 48, 4, 128, 217, 254, 167,
            114, 126, 46, 179, 36, 64, 3, 48, 216, 53, 50, 100, 80, 141, 48, 100, 32, 60, 109, 58, 216, 38, 218, 242,
            28, 117, 187, 163, 193, 168, 78, 6, 27, 200, 73, 103, 204, 80, 85, 174, 61, 143, 227, 84, 226, 127, 196,
            151, 18, 5, 128, 12, 187, 137, 68, 219, 159, 132, 113, 105, 243, 230, 96, 50, 26, 88, 102, 78, 102, 76, 14,
            252, 89, 180, 192, 85, 243, 127, 87, 123, 233, 136, 17, 174, 223, 103, 203, 187, 56, 129, 229, 199, 190,
            120, 25, 18, 61, 140, 197, 3, 66, 10, 65, 217, 235, 165, 62, 112, 119, 101, 106, 184, 203, 169, 184, 115, 2,
            205, 8, 125, 153, 84, 195, 215, 139, 249, 195, 102, 108, 79, 23, 177, 131, 212, 229, 39, 8, 176, 233, 188,
            216, 199, 37, 109, 122, 101, 81, 98, 178, 167, 215, 12, 37, 27, 137, 165, 249, 131, 40, 202, 162, 36, 184,
            88, 76, 185, 246, 167, 125, 116, 198, 109, 135, 98, 124, 223, 188, 186, 216, 155, 224, 237, 140, 52, 203,
            89, 65, 121, 251, 216, 85, 212, 164, 98, 204, 253, 102, 246, 19, 158, 187, 186, 60, 94, 44, 62, 147, 243,
            183, 82, 6, 28, 87, 198, 133, 28, 129, 12, 55, 84, 163, 238, 46, 176, 28, 132, 44, 199, 234, 28, 73, 27,
            190, 108, 85, 146, 53, 248, 134, 30, 227, 172, 250, 77, 225, 101, 105, 167, 99, 214, 192, 31, 3, 96, 52, 51,
            237, 165, 164, 101, 228, 88, 251, 44, 142, 225, 98, 72, 180, 50, 13, 66, 59, 173, 238, 197, 168, 188, 28,
            135, 195, 69, 247, 87, 216, 50, 52, 227, 16, 127, 162, 23, 58, 20, 120, 62, 184, 62, 122, 23, 209, 110, 168,
            26, 1, 182, 1, 130, 111, 224, 191, 93, 202, 68, 76, 243, 38, 225, 80, 219, 232, 145, 191, 84, 27, 69, 41,
            125, 229, 148, 119, 183, 52, 95, 219, 152, 41, 182, 89, 254, 166, 155, 125, 26, 233, 98, 150, 146, 10, 53,
            171, 176, 31, 138, 99, 74, 34, 228, 72, 202, 5, 120, 160, 135, 185, 222, 227, 42, 233, 74, 219, 101, 213, 2,
            112, 46, 108, 45, 49, 158, 185, 241, 83, 240, 167, 0, 140, 160, 194, 171, 2, 150, 96, 145, 214, 109, 31, 83,
            84, 62, 147, 54, 236, 193, 231, 187, 223, 83, 62, 251, 24, 79, 41, 30, 133, 241, 251, 191, 90, 187, 231,
            123, 115, 120, 41, 32, 134, 228, 202, 91, 81, 112, 34, 201, 223, 39, 208, 79, 117, 244, 151, 247, 98, 125,
            193, 220, 152, 195, 226, 1, 135, 24, 13, 227, 1, 24, 226, 101, 167, 131, 219, 173, 198, 31, 113, 248, 174,
            125, 159, 108, 79, 129, 7, 253, 13, 148, 21, 24, 123, 46, 56, 195, 15, 151, 197, 50, 251, 8, 48, 14, 164,
            51, 101, 46, 186, 241, 222, 221, 24, 99, 236, 255, 76, 3, 236, 67, 81, 154, 144, 196, 18, 119, 139, 127,
            241, 1, 89, 102, 172, 142, 87, 134, 56, 81, 120, 191, 242, 168, 237, 47, 143, 117, 146, 179, 137, 123, 243,
            14, 116, 94, 46, 219, 228, 209, 9, 94, 245, 83, 145, 153, 5, 62, 120, 49, 23, 36, 202, 50, 168, 108, 206,
            236, 119, 112, 187, 112, 120, 134, 62, 252, 108, 143, 115, 235, 254, 196, 119, 60, 163, 223, 188, 175, 57,
            77, 236, 99, 99, 197, 127, 196, 39, 58, 39, 24, 10, 212, 227, 37, 248, 219, 112, 161, 176, 82, 199, 97, 179,
            252, 60, 98, 209, 44, 161, 5, 63, 54, 154, 66, 9, 1, 56, 42, 25, 140, 75, 177, 135, 136, 212, 18, 241, 178,
            235, 115, 17, 99, 158, 113, 17, 4, 192, 30, 176, 238, 68, 171, 120, 76, 52, 145, 103, 30, 242, 130, 185, 85,
            19, 50, 180, 88, 213, 4, 62, 190, 238, 172, 203, 145, 233, 45, 53, 228, 144, 16, 180, 96, 89, 231, 141, 146,
            106, 199, 65, 241, 227, 173, 126, 204, 183, 18, 8, 18, 223, 196, 225, 151, 115, 0, 101, 21, 96, 49, 47, 130,
            18, 204, 70, 52, 189, 5, 107, 171, 47, 36, 209, 8, 166, 23, 183, 222, 154, 226, 13, 197, 166, 222, 197, 182,
            50, 155, 180, 156, 105, 244, 205, 226, 29, 128, 90, 126, 38, 9, 166, 195, 86, 22, 107, 253, 160, 163, 95,
            15, 23, 254, 115, 14, 219, 16, 159, 217, 116, 28, 13, 199, 147, 205, 182, 225, 185, 207, 89, 192, 169, 93,
            205, 226, 196, 204, 23, 168, 185, 121, 109, 126, 52, 222, 109, 248, 235, 64, 88, 101, 188, 246, 150, 193,
            90, 29, 131, 134, 149, 170, 240, 146, 169, 149, 250, 17, 49, 162, 6, 233, 194, 83, 210, 129, 141, 76, 115,
            151, 173, 48, 59, 48, 31, 48, 7, 6, 5, 43, 14, 3, 2, 26, 4, 20, 46, 139, 176, 16, 247, 139, 61, 176, 37, 63,
            246, 211, 123, 201, 3, 7, 235, 129, 230, 125, 4, 20, 175, 27, 113, 89, 19, 230, 155, 210, 161, 63, 10, 47,
            233, 189, 221, 31, 172, 172, 134, 47, 2, 2, 7, 208
        };

        /// <summary>
        /// Initializes a new instance of <see cref="DummyCertificate"/> with a static dummy certificate.
        /// </summary>
        public DummyCertificate() : base(CertificateBytes)
        {
        }
    }
}
