using Microsoft.Win32;
using PMS.Client.Common;
using PMS.Client.IBll;
using PMS.Client.SystemModule.Model;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace PMS.Client.SystemModule.ViewModels
{
    public class UploadViewModel : PageViewModelBase
    {

        public ObservableCollection<FileModel> Files { get; set; } = 
            new ObservableCollection<FileModel>();

        public DelegateCommand UploadCommand { get; set; }

        IFileService _fileService;

        public UploadViewModel(IRegionManager regionManager, 
            IFileService fileService) : base(regionManager)
        {
            this.PageTitle = "更新文件上传";
            _fileService = fileService;
            UploadCommand = new DelegateCommand(() => {
                index = 0; 
                DoUpload();
            });


            this.Refresh();
        }
        int index = 0;
        private void DoUpload()
        {
            /// 状态：
            /// 0 => 默认
            /// 1 等待上传 2 正在上传 3 上传完成   -1 上传失败
            if (index >= Files.Count) return;
            var file = Files[index];
            try
            {                
                // 只找需要上传的文件
                if (file.State != "1" )
                {
                    index++;
                    if(index < Files.Count) 
                        DoUpload();
                    return;
                }
                
                file.State = "2";
                _fileService.UploadFile(file.FullPath, file.FilePath,
                progress =>
                {
                    // 上传进度
                    file.ProgressValue = progress;
                }, completed =>
                {
                    // 异常判断
                    if(completed != null && completed.Error != null)
                    {
                        // 提示异常
                        throw new Exception(completed.Error.Message);
                    }
                    else
                    {
                        // 上传完成
                        file.State = "3";
                        file.ProgressValue = 100;

                        index++;
                        if (index < Files.Count)
                            DoUpload();

                    }
                });
            }
            catch (Exception ex)
            {
                file.Error = ex.Message;
                file.State = "-1";

                index++;
                if (index < Files.Count)
                    DoUpload();
            }
        }

        public override void Refresh()
        {
            Files.Clear();

            var files = _fileService.GetUpgradeFiles(this.SearchKey).ToList();

            for(int i = 0; i < files.Count(); i++)
            {
                var file = files[i];
                FileModel model = new FileModel();

                model.Index = i + 1;
                model.FileName = file.fileName;
                model.UploadTime = $"{file.uploadTime:yyyy-MM-dd HH:mm:ss}";
                model.FilePath = file.filePath;
                model.State = "1";

                Files.Add(model);
            }
        }

        public override void DoDelete(object model)
        {
            try
            {
                var m = model as FileModel;
                if(m.State == "3")
                {
                    int count = _fileService.DeleteFile(m.FileName);
                    if (count == 0) throw new Exception("删除文件失败");
                }                
                Files.Remove(m);
            }catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "提示");
            }
        }
        public override void DoModify(object model)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.Multiselect = true;
            if(openFileDialog.ShowDialog() == true)
            {
                // 文件名  完整路径
                string[] file_names = openFileDialog.SafeFileNames;

                /// 判断名称是否在表中  
                /// 在 =>设置，状态上传
                /// 不在 => 添加至列表
                for(int i = 0;i < file_names.Length; i++)
                {
                    var file = Files.FirstOrDefault(f => f.FileName == file_names[i]);
                    if(file != null)
                    {
                        file.FullPath = openFileDialog.FileNames[i];
                        file.State = "1"; // 等待上传
                    }
                    else
                    {
                        Files.Add(new FileModel
                        {
                            Index = Files.Count() + 1,
                            FileName = file_names[i],
                            FullPath = openFileDialog.FileNames[i],
                            FilePath = @".\",
                            State = "1"
                        });
                    }
                }
            }
        }
    }
}
