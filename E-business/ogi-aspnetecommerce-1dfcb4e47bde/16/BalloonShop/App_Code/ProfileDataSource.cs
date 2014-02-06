using System;
using System.Collections.Generic;

/// <summary>
/// A further wrapper around ProfileWrapper, exposing data
/// in a form usable by ObjectDataSource.
/// </summary>
public class ProfileDataSource
{
  public ProfileDataSource()
  {
  }

  public List<ProfileWrapper> GetData()
  {
    List<ProfileWrapper> data = new List<ProfileWrapper>();
    data.Add(new ProfileWrapper());
    return data;
  }

  public void UpdateData(ProfileWrapper newData)
  {
    newData.UpdateProfile();
  }
}
