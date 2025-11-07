export default function EditProfilePage()
{
  const handleSubmit = (e: React.FormEvent<HTMLFormElement>) => {
    e.preventDefault(); // stop page reload
    const formData = new FormData(e.currentTarget);
    const name = formData.get("name");
    const city = formData.get("city");
    const skillLevel = formData.get("skill_level");
    const bio = formData.get("bio");
    console.log({ name, city, skillLevel, bio });
  };
    return(
    <div className="max-w-4xl mx-auto py-10 px-4 sm:px-6 lg:px-8">
        <h2 className="text-4xl font-extrabold text-padel-primary mb-6">Edit Your Profile</h2>
        <div className="bg-white p-8 rounded-xl shadow-2xl border border-padel-accent/30 space-y-6">
        {/* Profile Picture Section   */}
            <div className="flex flex-col items-center border-b pb-6 mb-6">
                <div className="w-32 h-32 bg-gray-200 rounded-full flex items-center justify-center border-4 border-padel-accent overflow-hidden">
                    <span className="text-lg text-gray-500 "> Avatar</span>
                </div>
                    <button className="mt-4 px-4 py-2 text-sm font-semibold text-padel-primary border border-padel-primary rounded-full hover:bg-padel-primary hover:text-white transition duration-200 shadow-md ">
                        Change Photo
                    </button>
            </div>
        {/* Personal Details Section  */}
            <form className="space-y-6" onSubmit={handleSubmit}>
                <div className="grid grid-cols-1 md:grid-cols-2 gap-2">
                    <div>
                        <label htmlFor="name"  className="block text-sm font-medium text-padel-primary mb-1">Full Name</label>
                        <input type="text" autoComplete="off" id="name" name="name" placeholder="Write your name..."
                        className="w-full p-3 border border-gray-300 rounded-lg focus:ring-padel-accent focus:border-padel-accent transition duration-150"/>
                    </div>
                    <div>
                        <label htmlFor="city" className="block text-sm font-medium text-padel-primary mb-1">City / Location</label>
                        <input type="text" autoComplete="off" id="city" name="city" placeholder="Write your city..."
                            className="w-full p-3 border border-gray-300 rounded-lg focus:ring-padel-accent focus:border-padel-accent transition duration-150"></input>
                    </div>
                </div>
                <div>
                    <label htmlFor="skill_level" className="block text-sm font-medium text-padel-primary mb-1">Padel Skill Level</label>
                    <select id="skill_level" name="skill_level" defaultValue=""
                        className="w-full p-3 border border-gray-300 rounded-lg focus:ring-padel-accent focus:border-padel-accent transition duration-150 bg-white appearance-none">
                        <option className="text-gray-200" value="" disabled   >Select your level: </option>
                        <option value="1.0">Beginner (1.0)</option>
                        <option value="2.5">Novice (2.5)</option>
                        <option value="3.5" >Intermediate (3.5)</option>
                        <option value="4.5">Advanced (4.5)</option>
                        <option value="5.0">Expert (5.0+)</option>
                    </select>
                </div>
                <div>
                    <label htmlFor="bio" className="block text-sm font-medium text-padel-primary mb-1">Player Bio / Description</label>
                    <textarea id="bio" name="bio" rows={4} placeholder="Tell other players about yourself..."
                        className   ="w-full p-3 border border-gray-300 rounded-lg focus:ring-padel-accent
                        focus:border-padel-accent transition duration-150 resize-none">
                     </textarea>
                </div>
                  <div className="flex justify-end space-x-4 pt-4">
                   
                    <button type="button" 
                        onClick={() => (window.location.href = "/edit/profile")}
                        className="px-6 py-3 text-padel-primary font-semibold border border-padel-primary rounded-lg hover:bg-gray-100 transition duration-200 shadow-md">
                        Cancel
                    </button>
                    <button type="submit" 
                        className="px-6 py-3 bg-padel-accent text-white font-extrabold rounded-lg shadow-xl hover:bg-emerald-600 transition duration-200 transform hover:scale-[1.01]">
                        Save Changes
                    </button>
                </div>

            </form>

        </div>

    </div>);

}