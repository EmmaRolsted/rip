using System;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using AgentAssignment.Annotations;

namespace AgentAssignment
{
   public class Agents : ObservableCollection<Agent> { };  // Just to reference it from xaml

   [Serializable]
   public class Agent : INotifyPropertyChanged
   {
      string id;
      string codeName;
      string speciality;
      string assignment;

      public Agent()
      {
      }

      public Agent(string aId, string aName, string aAddress, string aSpeciality, string aAssignment)
      {
         id = aId;
         codeName = aName;
         speciality = aSpeciality;
         assignment = aAssignment;
      }

      public string ID
      {
         get
         {
            return id;
         }
         set
         {
            id = value;
         }
      }
       int currentIndex = -1;

       public int CurrentIndex
       {
           get { return currentIndex; }
           set
           {
               if (currentIndex != value)
               {
                   currentIndex = value;
                   OnPropertyChanged();
               }
           }
       }

        public string CodeName
      {
         get
         {
            return codeName;
         }
         set
         {
            codeName = value;
         }
      }

      public string Speciality
      {
         get
         {
            return speciality;
         }
         set
         {
            speciality = value;
         }
      }

      public string Assignment
      {
         get
         {
            return assignment;
         }
         set
         {
            assignment = value;
         }
      }

       public event PropertyChangedEventHandler PropertyChanged;

       [NotifyPropertyChangedInvocator]
       protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
       {
           PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
       }
   }
}
