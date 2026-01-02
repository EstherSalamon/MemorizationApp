import { Route, Routes } from 'react-router-dom';
import { Layout } from './common/Components/Layout/Layout';
import { HomePage } from './Pages/Home/HomePage';
import { ViewRecitalPage } from './Pages/View/ViewRecitalPage';
import { TestRecitalPage } from './Pages/Test/TestRecitalPage';
import { AddRecitalPage } from './Pages/Add/AddRecitalPage';

const App = () => {
    return (
        <Layout>
            <Routes>
                <Route path='/' element={<HomePage />} />
                <Route path='/rec/view/:id' element={<ViewRecitalPage />} />
                <Route path='/rec/test/:id?' element={<TestRecitalPage />} />
                <Route path='/rec/add' element={<AddRecitalPage />} />
            </Routes>
        </Layout>
    );
}

export default App;

// TODO: id as searchparam, not path