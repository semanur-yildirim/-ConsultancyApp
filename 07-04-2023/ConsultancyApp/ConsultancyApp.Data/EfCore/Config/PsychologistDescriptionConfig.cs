using ConsultancyApp.Entity.Concrete;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsultancyApp.Data.EfCore.Config
{
    public class PsychologistDescriptionConfig:IEntityTypeConfiguration<PsychologistDescription>
    {

        public void Configure(EntityTypeBuilder<PsychologistDescription> builder)
        {
            builder.Property(x => x.Id).ValueGeneratedOnAdd();
            builder.Property(x => x.About).IsRequired().HasMaxLength(1000);
            builder.Property(x => x.Education).IsRequired().HasMaxLength(250);
            builder.Property(x => x.Experience).IsRequired().HasMaxLength(250);
            builder.Property(x => x.GraduationYear).IsRequired();
            builder.HasData(
                new PsychologistDescription { Id=1, GraduationYear=new DateTime(2000,12,5),Education= "İzmir Üniversitesi Psikoloji", BirthDate=new DateTime(1978,5,2),Experience= "Online ve Yüz yüze Terapi",About= "Sosyal Terapist, Bağımlılık Terapisti, Psikodrama Yöneticisi, Organizasyon Geliştirici İzmir Üniversitesi bölümünü tamamlayıp, ardından Almanya’da Sağlık Managment Yüksek Lisans Master egitimini  Magdeburg-Stendal Yüksekokulunda tamamlamıştır. Almanya’da psikososyal alanda 1982 yılından itibaren mesleki calışmasına paralel, 2013 tarihine kadar Sosyalterapi, Bagimlilik terapisti, Psikodrama Grup Yöneticisi, Organizasyon Geliştirici ve Choac  eğitimlerini aldı."},
                 new PsychologistDescription { Id = 2, GraduationYear = new DateTime(2005, 7, 15), Education = "Hacettepe Üniversitesi Psikoloji", BirthDate = new DateTime(1980, 3, 12), Experience = "Bireysel ve Grup Terapisi", About = "Bireysel terapi, grup terapisi, cinsel sağlık, madde bağımlılığı, anksiyete ve depresyon konularında uzmanım. Terapi sürecinde öncelikle güvenli bir ilişki kurmayı hedeflerim. İletişim becerileri, bilişsel davranışçı terapi, psikodinamik yaklaşım gibi farklı terapi yöntemleri kullanırım."},
                new PsychologistDescription { Id = 3, GraduationYear = new DateTime(2007, 6, 25), Education = "Boğaziçi Üniversitesi Psikoloji", BirthDate = new DateTime(1985, 9, 18), Experience = "Depresyon ve Anksiyete Terapisi", About = "İyi bir dinleyici ve gözlemciyim. Terapi sürecinde öncelikle danışanın sorunlarına odaklanarak, onun düşünce ve duygularını anlamaya çalışırım. Depresyon, anksiyete, panik atak gibi konularda terapi süreci yürütmekteyim."},
                new PsychologistDescription { Id = 4, GraduationYear = new DateTime(2010, 8, 11), Education = "Ankara Üniversitesi Psikoloji", BirthDate = new DateTime(1979, 2, 8), Experience = "Çocuk ve Aile Terapisi", About = "Çocuklar ve ailelerine yönelik terapi süreçlerinde, oyun terapisi, sanat terapisi ve aile danışmanlığı gibi yöntemleri kullanmaktayım. Her çocuğun farklı bir yapısı olduğunu ve ona göre bir terapi planı hazırlanması gerektiğini düşünmekteyim."},
                 new PsychologistDescription { Id = 5, GraduationYear = new DateTime(2002, 11, 29), Education = "İstanbul Üniversitesi Psikoloji", BirthDate = new DateTime(1976, 7, 23), Experience = "Stres ve Öfke Yönetimi", About = "Stres ve öfke yönetimi konularında uzmanım. Terapi sürecinde, danışanın stres ve öfke seviyesini düşürmek için birlikte çalışırız. Bunun için bilişsel davranışçı terapi, nefes egzersizleri, meditasyon ve benzeri yöntemler kullanmaktayım."},
                new PsychologistDescription { Id = 6, GraduationYear = new DateTime(2008, 7, 15), Education = "Ankara Üniversitesi Psikoloji", BirthDate = new DateTime(1985, 3, 18), Experience = "Aile Terapisi, Çift Terapisi", About = "Ankara Üniversitesi Psikoloji bölümünden mezun olan psikolog, çift terapisi ve aile terapisi konularında uzmanlaşmıştır. Terapi yöntemleri arasında Bilişsel-Davranışçı Terapi, Çözüm Odaklı Terapi ve Şema Terapi bulunmaktadır." },
               new PsychologistDescription { Id = 7, GraduationYear = new DateTime(2005, 9, 1), Education = "Boğaziçi Üniversitesi Psikoloji", BirthDate = new DateTime(1982, 12, 10), Experience = "Ergen Terapisi, Bağımlılık Terapisi", About = "Boğaziçi Üniversitesi Psikoloji bölümünden mezun olan psikolog, ergen terapisi ve bağımlılık terapisi konularında uzmanlaşmıştır. Terapi yöntemleri arasında Bilişsel-Davranışçı Terapi, Motivasyonel Röportaj ve EMDR bulunmaktadır." },
                new PsychologistDescription { Id = 8, GraduationYear = new DateTime(2012, 6, 25), Education = "Hacettepe Üniversitesi Psikoloji", BirthDate = new DateTime(1989, 8, 20), Experience = "Stres Yönetimi, Depresyon Terapisi", About = "Hacettepe Üniversitesi Psikoloji bölümünden mezun olan psikolog, stres yönetimi ve depresyon terapisi konularında uzmanlaşmıştır. Terapi yöntemleri arasında Bilişsel-Davranışçı Terapi, Psikanalitik Terapi ve EFT bulunmaktadır." },
                new PsychologistDescription { Id = 9, GraduationYear = new DateTime(2003, 3, 1), Education = "İstanbul Üniversitesi Psikoloji", BirthDate = new DateTime(1980, 6, 12), Experience = "Bireysel Terapi, Çift Terapisi, Aile Terapisi", About = "İstanbul Üniversitesi Psikoloji bölümünden mezun olan psikolog, bireysel terapi, çift terapisi ve aile terapisi konularında uzmanlaşmıştır. Terapi yöntemleri arasında Bilişsel-Davranışçı Terapi, Şema Terapi ve Gestalt Terapi bulunmaktadır." },
                new PsychologistDescription { Id = 10, GraduationYear = new DateTime(2008, 7, 15), Education = "Hacettepe Üniversitesi Psikoloji", BirthDate = new DateTime(1985, 2, 18), Experience = "Çocuk ve Aile Terapisi", About = "Çocuklarla ve aileleriyle çalışmayı seven bir terapistim. Özellikle, çocuklarda davranış sorunları, kaygı, depresyon ve dikkat eksikliği konularında deneyimim var. Tedavide, bütünsel bir yaklaşım benimsemekteyim ve bu doğrultuda bireysel terapi, aile terapisi ve ebeveyn rehberliği gibi yöntemleri kullanmaktayım."}
                   
            );
        }
    }
}
