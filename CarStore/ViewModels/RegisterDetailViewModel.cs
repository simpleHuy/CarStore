using System.Collections.ObjectModel;
using System.Windows.Input;
using CarStore.Contracts.ViewModels;
using CarStore.Core.Contracts.Repository;
using CarStore.Core.Contracts.Services;
using CarStore.Core.Models;

using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;

namespace CarStore.ViewModels;

public partial class RegisterDetailViewModel : ObservableRecipient
{
    private readonly IDao<RegisterDetail> _RegisterDetailDao;
    private readonly IDao<User> _UserDao;
    private readonly IDao<Showroom> _showroomDao;
    private readonly IShowroomRepository showroomRepository;
    public ObservableCollection<RegisterDetail> RegisterDetails
    {
        get;set;
    } = new ObservableCollection<RegisterDetail>();

    public RegisterDetailViewModel(IDao<RegisterDetail> registerDetailDao, IDao<User> userDao, IShowroomRepository showroomRepository, 
                IDao<Showroom> showroomDao)
    {
        _RegisterDetailDao = registerDetailDao;
        _UserDao = userDao;
        _showroomDao = showroomDao;
        this.showroomRepository = showroomRepository;
        Task.Run(async () =>
        {
            RegisterDetails = new ObservableCollection<RegisterDetail>(await _RegisterDetailDao.GetAllAsync());
            foreach (var item in RegisterDetails)
            {
                item.User = await _UserDao.GetByIdAsync(item.UserId);
            }
        }).Wait();
    }

    public async void AcceptRegister(RegisterDetail detail)
    {
        var content = detail.Content;
        if(content == "showroom")
        {
            var user = await _UserDao.GetByIdAsync(detail.UserId);
            user.IsShowroom = true;
            await _UserDao.Update(user);
        }
        else if (content == "reputation")
        {
            var showroom = await showroomRepository.GetShowroomByUserId(detail.UserId);
            showroom.IsReputation = true;
            await _showroomDao.Update(showroom);
        }

        await _RegisterDetailDao.DeleteById(detail.Id);
        RegisterDetails.Remove(detail);
    }

    public async void RefuseRegister(RegisterDetail detail)
    {
        await _RegisterDetailDao.DeleteById(detail.Id);
        RegisterDetails.Remove(detail);
    }

}
