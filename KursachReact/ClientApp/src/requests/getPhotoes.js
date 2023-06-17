async function getPhoto(id) {
  try {
    const response = await fetch("api/advertisements/get-photoes/" + id, {
      headers: {
        'Cache-Control': 'no-cache',
      },
    });

    if (!response.ok) {
      throw new Error('Request failed');
    }

    const data = await response.json();
    return data;
  } catch (error) {
    console.log(error);
    return [];
  }
}

export default getPhoto;
